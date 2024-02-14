﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Mvc;
using SimpleIdServer.IdServer.Api.Token.Handlers;
using SimpleIdServer.IdServer.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Api.Token
{
    public interface ITokenRequestHandler
    {
        Task<IActionResult> Handle(HandlerContext context, CancellationToken token);
    }

    public class TokenRequestHandler : ITokenRequestHandler
    {
        private readonly IEnumerable<IGrantTypeHandler> _handlers;

        public TokenRequestHandler(IEnumerable<IGrantTypeHandler> handlers)
        {
            _handlers = handlers;
        }

        public virtual Task<IActionResult> Handle(HandlerContext context, CancellationToken token)
        {
            var handler = _handlers.FirstOrDefault(h => h.GrantType == context.Request.RequestData.GetGrantType());
            if (handler == null) return Task.FromResult(BaseCredentialsHandler.BuildError(HttpStatusCode.BadRequest, ErrorCodes.INVALID_GRANT, Global.BadGrantType));
            return handler.Handle(context, token);
        }
    }
}