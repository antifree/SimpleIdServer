﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using SimpleIdServer.Did.Extensions;
using SimpleIdServer.Did.Models;
using System;
using System.Linq;
using System.Text.Json.Nodes;

namespace SimpleIdServer.Did.Crypto
{
    public class Ed25519SignatureKey : ISignatureKey
    {
        private Ed25519PublicKeyParameters _publicKey;
        private Ed25519PrivateKeyParameters _privateKey;

        public Ed25519SignatureKey(byte[] publicKey, byte[] privateKey)
        {
            if (publicKey != null)
            {
                if (publicKey.Length != 32) throw new InvalidOperationException("Public key must have 32 bytes");
                _publicKey = new Ed25519PublicKeyParameters(publicKey);
            }

            if (privateKey != null)
            {
                if (privateKey.Length != 64 && privateKey.Length != 32) throw new InvalidOperationException("Private key must have 64 or 32 bytes");
                _privateKey = new Ed25519PrivateKeyParameters(privateKey.Take(32).ToArray());
                if (privateKey.Length == 64) _publicKey = new Ed25519PublicKeyParameters(privateKey.Skip(32).ToArray());
            }
        }

        public string Name => Constants.SupportedSignatureKeyAlgs.Ed25519;

        public byte[] PrivateKey
        {
            get
            {
                if (_privateKey == null) return null;
                return _privateKey.GetEncoded();
            }
        }

        public byte[] GetPublicKey(bool compressed = false)
        {
            if (_publicKey == null) return null;
            return _publicKey.GetEncoded();
        }

        public JsonObject GetPublicKeyJwk()
        {
            return new JsonObject
            {
                { "kty", "OKP" },
                { "crv", "Ed25519" },
                { "x", Base64UrlEncoder.Encode(_publicKey.GetEncoded()) }
            };
        }

        public bool Check(string content, string signature) => Check(System.Text.Encoding.UTF8.GetBytes(content), Base64UrlEncoder.DecodeBytes(signature));

        public bool Check(byte[] payload, byte[] signaturePayload)
        {
            if (_publicKey == null) throw new InvalidOperationException("There is no public key");
            var verifier = new Ed25519Signer();
            verifier.Init(false, _publicKey);
            verifier.BlockUpdate(payload, 0, payload.Length);
            return verifier.VerifySignature(signaturePayload);
        }

        public string Sign(string content) => Sign(System.Text.Encoding.UTF8.GetBytes(content));

        public string Sign(byte[] payload)
        {
            if (_privateKey == null) throw new InvalidOperationException("There is no private key");
            var signer = new Ed25519Signer();
            signer.Init(true, _privateKey);
            signer.BlockUpdate(payload, 0, payload.Length);
            return Base64UrlEncoder.Encode(signer.GenerateSignature());
        }

        public IdentityDocumentVerificationMethod ExtractVerificationMethodWithPublicKey()
        {
            return new IdentityDocumentVerificationMethod
            {
                PublicKeyHex = _publicKey.GetEncoded().ToHex()
            };
        }
    }
}
