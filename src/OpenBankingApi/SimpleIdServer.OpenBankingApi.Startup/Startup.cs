﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using MediatR;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleIdServer.Jwt;
using SimpleIdServer.Jwt.Extensions;
using SimpleIdServer.Jwt.Jwe.CEKHandlers;
using SimpleIdServer.OpenBankingApi.Infrastructure.Filters;
using SimpleIdServer.OpenBankingApi.Persistences;
using SimpleIdServer.OpenID;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace SimpleIdServer.OpenBankingApi.Startup
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var firstMtlsClientJsonWebKey = ExtractJsonWebKeyFromRSA("first_mtlsClient_key.txt", "PS256");
            var secondMtlsClientJsonWebKey = ExtractJsonWebKeyFromRSA("second_mtlsClient_key.txt", "PS256");
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                option.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                .AddCertificate(o =>
                {
                    o.RevocationFlag = X509RevocationFlag.EntireChain;
                    o.RevocationMode = X509RevocationMode.NoCheck;
                });
            services.AddAuthorization(opts =>
            {
                opts.AddDefaultOAUTHAuthorizationPolicy();
                opts.AddOpenBankingAuthorization(CertificateAuthenticationDefaults.AuthenticationScheme);
            });

            services.AddMediatR(typeof(IAccountRepository));
            services.AddSwaggerGen();
            services.AddSIDOpenID(opt =>
            {
                opt.IsLocalhostAllowed = true;
                opt.IsRedirectionUrlHTTPSRequired = false;
                opt.IsInitiateLoginUriHTTPSRequired = true;
                opt.DefaultAcrValue = "urn:openbanking:psd2:ca";
            }, opt =>
            {
                opt.MtlsEnabled = true;
                opt.DefaultScopes = new List<string>
                    {
                        SIDOpenIdConstants.StandardScopes.Profile.Name,
                        SIDOpenIdConstants.StandardScopes.Email.Name,
                        SIDOpenIdConstants.StandardScopes.Address.Name,
                        SIDOpenIdConstants.StandardScopes.Phone.Name
                    };
            })
                .AddClients(DefaultConfiguration.GetClients(firstMtlsClientJsonWebKey, secondMtlsClientJsonWebKey), DefaultConfiguration.Scopes)
                .AddAcrs(DefaultConfiguration.AcrLst)
                .AddUsers(DefaultConfiguration.Users)
                .AddJsonWebKeys(GenerateJsonWebKeys())
                .AddLoginPasswordAuthentication();
            services.AddOpenBankingApi()
                .AddAccounts(DefaultConfiguration.Accounts);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenBanking V1");
            });
            app.UseOpenBankingAPI();
            app.UseSIDOpenId();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "AreaRoute",
                  template: "{area}/{controller}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "DefaultRoute",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static JsonWebKey ExtractJsonWebKeyFromRSA(string fileName, string algName)
        {
            using (var rsa = RSA.Create())
            {
                var json = File.ReadAllText(fileName);
                var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                rsa.Import(dic);
                return new JsonWebKeyBuilder().NewSign("1", new[]
                {
                    KeyOperations.Sign,
                    KeyOperations.Verify
                }).SetAlg(rsa, algName).Build();
            }
        }

        private static List<JsonWebKey> GenerateJsonWebKeys()
        {
            JsonWebKey sigJsonWebKey;
            JsonWebKey encJsonWebKey;
            using (var rsa = RSA.Create())
            {
                sigJsonWebKey = new JsonWebKeyBuilder().NewSign("1", new[]
                {
                    KeyOperations.Sign,
                    KeyOperations.Verify
                }).SetAlg(rsa, "PS256").Build();
            }

            using (var rsa = RSA.Create())
            {
                encJsonWebKey = new JsonWebKeyBuilder().NewEnc("2", new[]
                {
                    KeyOperations.Encrypt,
                    KeyOperations.Decrypt
                }).SetAlg(rsa, RSAOAEPCEKHandler.ALG_NAME).Build();
            }

            return new List<JsonWebKey>
            {
                sigJsonWebKey,
                encJsonWebKey
            };
        }
    }
}