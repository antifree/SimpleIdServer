﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Domains;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Authenticate.Handlers
{
    public class OAuthClientSecretBasicAuthenticationHandler : IOAuthClientAuthenticationHandler
    {
        public OAuthClientSecretBasicAuthenticationHandler() { }

        public string AuthMethod => AUTH_METHOD;
        public const string AUTH_METHOD = "client_secret_basic";

        public Task<bool> Handle(AuthenticateInstruction authenticateInstruction, Client client, string expectedIssuer, CancellationToken cancellationToken, string errorCode = ErrorCodes.INVALID_CLIENT)
        {
            if (authenticateInstruction == null) throw new ArgumentNullException(nameof(authenticateInstruction));
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (string.IsNullOrWhiteSpace(client.ClientSecret)) return Task.FromResult(false);
            var result = string.Compare(client.ClientSecret, authenticateInstruction.ClientSecretFromAuthorizationHeader, StringComparison.CurrentCultureIgnoreCase) == 0;
            return Task.FromResult(result);
        }
    }
}
