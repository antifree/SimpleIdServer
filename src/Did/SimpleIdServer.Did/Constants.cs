﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SimpleIdServer.Did;

public static class Constants
{
    public class SupportedSignatureKeyAlgs
    {
        public const string Ed25519 = "Ed25519";
        public const string ES256K = "ES256K";
        public const string ES256 = "ES256";
        public const string ES384 = "ES384";
        public const string RSA = "RSA";
    }

    public const string DefaultIdentityDocumentContext = "https://www.w3.org/ns/did/v1";
    public const string Scheme = "did";
}
