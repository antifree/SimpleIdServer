﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using SimpleIdServer.IdServer.Api.BCCallback;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.DTOs;
using SimpleIdServer.IdServer.Jwt;
using SimpleIdServer.IdServer.Store;
using SimpleIdServer.IdServer.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.UI
{
    public class BackChannelConsentsController : Controller
    {
        private readonly IDataProtector _dataProtector;
        private readonly IClientRepository _clientRepository;
        private readonly IdServer.Infrastructures.IHttpClientFactory _httpClientFactory;
        private readonly IJwtBuilder _jwtBuilder;
        private readonly ITokenRepository _tokenRepository;
        private readonly ILogger<BackChannelConsentsController> _logger;

        public BackChannelConsentsController(
            IDataProtectionProvider dataProtectionProvider,
            IClientRepository clientRepository,
            IdServer.Infrastructures.IHttpClientFactory httpClientFactory,
            IJwtBuilder jwtBuilder,
            ITokenRepository tokenRepository,
            ILogger<BackChannelConsentsController> logger)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("Authorization");
            _clientRepository = clientRepository;
            _httpClientFactory = httpClientFactory;
            _jwtBuilder = jwtBuilder;
            _tokenRepository = tokenRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index([FromRoute] string prefix, string returnUrl, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Errors", new { code = "invalid_request", ReturnUrl = $"{Request.Path}{Request.QueryString}", area = string.Empty });

            try
            {
                var queries = ExtractQuery(returnUrl);
                if (!User.Identity.IsAuthenticated)
                {
                    var amr = queries["amr"].GetValue<string>();
                    returnUrl = $"{Request.GetAbsoluteUriWithVirtualPath()}{Url.Action("Index", "BackChannelConsents")}?returnUrl={returnUrl}";
                    return RedirectToAction("Index", "Authenticate", new { area = amr, ReturnUrl = _dataProtector.Protect(returnUrl) });
                }

                var viewModel = await BuildViewModel(prefix, queries, returnUrl, cancellationToken);

                return View(viewModel);
            }
            catch(CryptographicException)
            {
                return RedirectToAction("Index", "Errors", new { code = "cryptography_error", ReturnUrl = $"{Request.Path}{Request.QueryString}", area = string.Empty });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromRoute] string prefix, ConfirmBCConsentsViewModel confirmConsentsViewModel, CancellationToken cancellationToken)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Errors", new { code = "unauthorized", ReturnUrl = $"{Request.Path}{Request.QueryString}", area = string.Empty });
            if (confirmConsentsViewModel == null) 
                return RedirectToAction("Index", "Errors", new { code = "invalid_request", ReturnUrl = $"{Request.Path}{Request.QueryString}", area = string.Empty });

            var viewModel = new BCConsentsIndexViewModel
            {
                ReturnUrl = confirmConsentsViewModel.ReturnUrl
            };
            try
            {
                var issuer = $"{Request.GetAbsoluteUriWithVirtualPath()}/{Constants.EndPoints.BCCallback}";
                if(!string.IsNullOrWhiteSpace(prefix))                
                    issuer = $"{Request.GetAbsoluteUriWithVirtualPath()}/{prefix}/{Constants.EndPoints.BCCallback}";

                var queries = ExtractQuery(confirmConsentsViewModel.ReturnUrl);
                viewModel = await BuildViewModel(prefix, queries, viewModel.ReturnUrl, cancellationToken);
                var parameter = new BCCallbackParameter
                {
                    ActionEnum = confirmConsentsViewModel.IsRejected ? BCCallbackActions.REJECT : BCCallbackActions.CONFIRM,
                    AuthReqId = viewModel.AuthReqId
                };
                var sub = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Claims = new Dictionary<string, object>
                    {
                        { JwtRegisteredClaimNames.Sub, sub },
                    }
                };
                var accessToken = _jwtBuilder.Sign(prefix ?? Constants.DefaultRealm, tokenDescriptor, SecurityAlgorithms.RsaSha256);
                _tokenRepository.Add(new Domains.Token
                {
                    Id = accessToken,
                    ClientId = viewModel.ClientId,
                    CreateDateTime = DateTime.UtcNow,
                    TokenType = DTOs.TokenResponseParameters.AccessToken,
                    AccessTokenType = AccessTokenTypes.Jwt
                });
                await _tokenRepository.SaveChanges(cancellationToken);
                using (var httpClient = _httpClientFactory.GetHttpClient())
                {
                    var json = JsonSerializer.Serialize(parameter);
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(issuer),
                        Content = new StringContent(JsonSerializer.Serialize(parameter), System.Text.Encoding.UTF8, "application/json")
                    };
                    request.Headers.Add(Constants.AuthorizationHeaderName, $"{AutenticationSchemes.Bearer} {accessToken}");
                    var responseMessage = await httpClient.SendAsync(request, cancellationToken);
                    try
                    {
                        responseMessage.EnsureSuccessStatusCode();
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.ToString());
                        ModelState.AddModelError("invalid_request", "cannot_confirm_or_reject");
                        return View(viewModel);
                    }
                }

                viewModel.IsConfirmed = true;
                viewModel.ConfirmationStatus = confirmConsentsViewModel.IsRejected ? ConfirmationStatus.REJECTED : ConfirmationStatus.CONFIRMED;
                return View(viewModel);
            }
            catch (CryptographicException)
            {
                ModelState.AddModelError("invalid_request", "cryptography_error");
                return View(viewModel);
            }
        }

        private async Task<BCConsentsIndexViewModel> BuildViewModel(string realm, JsonObject queries, string returnUrl, CancellationToken cancellationToken)
        {
            var viewModel = new BCConsentsIndexViewModel
            {
                AuthReqId = queries.GetAuthReqId(),
                ClientId = queries.GetClientId(),
                BindingMessage = queries.GetBindingMessage(),
                AuthorizationDetails = queries.GetAuthorizationDetailsFromAuthorizationRequest(),
                Scopes = queries.GetScopes(),
                ReturnUrl = returnUrl
            };
            var str = realm ?? Constants.DefaultRealm;
            var client = await _clientRepository.Query()
                .Include(c => c.Translations)
                .Include(c => c.Realms)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClientId == viewModel.ClientId && c.Realms.Any(r => r.Name == str), cancellationToken);
            viewModel.ClientName = client.ClientName;
            return viewModel;
        }

        private JsonObject ExtractQuery(string returnUrl)
        {
            var unprotectedUrl = _dataProtector.Unprotect(returnUrl);
            var query = unprotectedUrl.GetQueries().ToJsonObject();
            if (query.ContainsKey("returnUrl"))
                return ExtractQuery(query["returnUrl"].GetValue<string>());

            return query;
        }
    }
}
