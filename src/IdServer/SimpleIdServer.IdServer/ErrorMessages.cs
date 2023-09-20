﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SimpleIdServer.IdServer
{
    public class ErrorMessages
    {
        public const string AUTHENTICATION_METHOD_NOT_FOUND = "the authentication method {0} doesn't exist";
        public const string ACCESS_REVOKED_BY_RESOURCE_OWNER = "access has been revoked by the resource owner";
        public const string OPENID_SCOPE_MISSING = "openid scope is missing";
        public const string UNKNOWN_SCOPE = "unknown scope {0}";
        public const string UNKNOWN_CLIENT = "unknown client {0}";
        public const string UNKNOWN_USER = "unknown user {0}";
        public const string UNKNOWN_AUTH_METHOD = "unknown authentication method : {0}";
        public const string UNKNOWN_TOKEN_TYPE_HINT = "unknown token type hint : {0}";
        public const string UNKNOWN_JSON_WEBKEY = "Json Web Key doesn't exist";
        public const string UNKNOWN_PERMISSIONS = "the permissions {0} don't exist";
        public const string UNKNOWN_BC_AUTHORIZE = "the back channel authorization {0} doesn't exist";
        public const string UNKNOWN_DEVICE_TYPE = "the device {0} is not supported";
        public const string UNKNOWN_GRANT = "the grant {0} doesn't exist";
        public const string UNKNOWN_REGISTRATION_WORKFLOW = "no registration workflow has been resolved";
        public const string UNKNOWN_ACCESS_TOKEN = "either the access token has been revoked or is invalid";
        public const string UNKNOWN_UMA_RESOURCE = "the UMA resource doesn't exist";
        public const string UNKNOWN_GROUP_IDS = "the group {0} don't exist";
        public const string UNKNOWN_CREDENTIAL_OFFER = "the credential offer doesn't exist";
        public const string UNKNOWN_DEVICE_CODE = "the device_code doesn't exist";
        public const string UNKNOWN_NETWORK = "the network {0} doesn't exist";
        public const string UNKNOWN_ACR = "the acr {0} doesn't exist";
        public const string UNKNOWN_AUTH_SCHEME_PROVIDER = "the authentication scheme provider {0} doesn't exist";
        public const string UNKNOWN_IDPROVISIONING = "the identity provisioning {0} doesn't exist";
        public const string UNKNOWN_IDPROVISIONING_MAPPINGRULE = "the mapping rule {0} doesn't exist";
        public const string UNKNOWN_AUTH_SCHEME_PROVIDER_PROPERTIES = "the authentication scheme provider cannot be updated because the following properties are unknown : {0}";
        public const string UNAUTHORIZED_CLIENT = "unauthorized client";
        public const string UNAUTHORIZED_ACCESSTOKEN = "the access token is not authorized to access to the operation";
        public const string UNAUTHORIZED_USER_ACCESS_GRANT = "the user {0} is not authorized to access to performance operations on the grant";
        public const string UNAUTHORIZED_CLIENT_ACCESS_GRANT = "the client {0} is not authorized to access to perform operations on the grant";
        public const string UNAUTHORIZED_ACCESS_PERMISSION_API = "you're not authorized to access to the permissions endpoint";
        public const string UKNOWN_RESOURCE = "following resources {0} doesn't exist";
        public const string NO_CLIENT_SECRET = "no client secret";
        public const string NO_CONSENT = "no consent has been accepted";
        public const string NO_JWK_WITH_ALG_SIG = "no JWK with algorithm {0} has been found to sign the JWT";
        public const string NO_JWK_FOUND_TO_DECRYPT = "no JWK with identifier {0} has been found to decrypt the JWT";
        public const string NO_JWK_FOUND_TO_CHECK_SIG = "no JWK with identifier {0} has been found to check the signature of the JWT";
        public const string DUPLICATE_SCOPES = "duplicate scopes : {0}";
        public const string UNAUTHORIZED_TO_SCOPES = "unauthorized to scopes : {0}";
        public const string INVALID_CLAIMS = "claims {0} are invalid";
        public const string INVALID_DPOP_HEADER = "the DPoP parameter must be a string";
        public const string INVALID_PREAUTHORIZEDCODE = "either the pre-authorized code has expired or is invalid";
        public const string INVALID_IDTOKENHINT = "id_token_hint is invalid";
        public const string INVALID_ISSUED_DEVICE_CODE = "the device code has already been used to get a token";
        public const string INVALID_PIN = "the pin is invalid";
        public const string INVALID_UMA_PERMISSION_SCOPE = "At least one of the scopes included in the request does not match an available scope for any of the resources associated with requested permissions for the permission ticket provided by the client.";
        public const string INVALID_HTTPS_INITIATE_LOGIN_URI = "initiate_login_uri doesn't contain https scheme";
        public const string INVALID_AUDIENCE = "invalid audiences";
        public const string INVALID_INITIATE_LOGIN_URI = "initiate_login_uri is not a valid URI";
        public const string INVALID_USER_CODE = "the user_code is not valid";
        public const string INVALID_HTTPS_REDIRECT_URI = "redirect_uri does not contain https scheme";
        public const string INVALID_LOCALHOST_REDIRECT_URI = "redirect_uri must not contain localhost";
        public const string INVALID_SCOPE = "At least one of the scopes included in the request does not match an available scope for any of the resources associated with requested permissions for the permission ticket provided by the client.";
        public const string INVALID_SUBJECT_TYPE = "subject_type is invalid";
        public const string INVALID_BC_DELIVERY_MODE = "invalid back channel delivery mode";
        public const string INVALID_EXPIRED_DEVICE_CODE = "the device code is expired";
        public const string INVALID_BC_CLIENT_NOTIFICATION_EDP = "invalid back channel client notification endpoint";
        public const string INVALID_HTTPS_BC_CLIENT_NOTIFICATION_EDP = "client notification endpoint doesn't contain https scheme";
        public const string INVALID_REQUEST_PARAMETER = "request parameter is invalid";
        public const string INVALID_JWE_REQUEST_PARAMETER = "request parameter is not a valid JWE token";
        public const string INVALID_TICKET = "permission ticket is not correct";
        public const string INVALID_RESOURCE_ID = "At least one of the provided resource identifiers was not found at the authorization server.";
        public const string INVALID_ACCESS_TOKEN_SCOPE = "access token has an invalid scope";
        public const string INVALID_JWS_REQUEST_PARAMETER = "request parameter is not a valid JWS token";
        public const string INVALID_REQUEST_URI_PARAMETER = "request_uri parameter is invalid";
        public const string INVALID_PENDING_DEVICE_CODE = "authorization request is still pending as the end user hasn't yet completed the user-interation steps";
        public const string INVALID_INCOMING_REQUEST = "incoming request is invalid";
        public const string INVALID_ENC_OR_ALG_USED_TO_ENCRYPT_IDTOKENHINT = "the alg / enc used to encrypt the id_token_hint is invalid";
        public const string INVALID_SECTOR_IDENTIFIER_URI = "sector_identifier_uri is not a valid URI";
        public const string INVALID_HTTPS_SECTOR_IDENTIFIER_URI = "sector_identifier_uri doesn't contain https scheme";
        public const string INVALID_ALG_USED_TO_SIGN_IDTOKENHINT = "the alg used to sign the id_token_hint is invalid";
        public const string INVALID_RESPONSE_TYPE_CLAIM = "the response_type claim is invalid";
        public const string INVALID_CLIENT_ID_CLAIM = "the client_id claim is invalid";
        public const string INVALID_DPOP_BOUND_TO_ACCESS_TOKEN = "DPoP must be bound to the access token";
        public const string INVALID_SIGNATURE_ALG = "the signature algorithm is invalid";
        public const string INVALID_AUTH_REQUEST_ID = "authorization request doesn't exist";
        public const string INVALID_CLIENT_IDTOKENHINT = "client_id contained in the id_token_hint is invalid";
        public const string INVALID_POST_LOGOUT_REDIRECT_URI = "post_logout_redirect_uri parameter is invalid";
        public const string INVALID_SUBJECT_IDTOKENHINT = "subject contained in id_token_hint is invalid";
        public const string INVALID_AUDIENCE_IDTOKENHINT = "audience contained in id_token_hint is invalid";
        public const string INVALID_APPLICATION_TYPE = "application type is invalid";
        public const string INVALID_AUTH_DEVICE_STATUS_FOR_REJECTION = "the status of the authentication device is invalid, it must be equals to PENDING";
        public const string INVALID_GRANT_MANAGEMENT_ACTION = "the grant_management_action {0} is not valid";
        public const string INVALID_AUTH_DETAILS_LOCATION = "the authorization_details location must be equal to the authorization server {0}";
        public const string INVALID_DECENTRALIZED_IDENTITY_METHOD = "the decentralized identity method {0} doesn't exist";
        public const string INVALID_JWT = "JSON Web Token cannot be read";
        public const string INVALID_NETWORK_NAME = "the network name already exists";
        public const string INVALID_CLIENT_ID_DEVICE_CODE = "the device code has not been issued for this client";
        public const string BAD_CODE_VERIFIER = "code_verifier is invalid";
        public const string BAD_TOKEN_FORMAT = "token format {0} is invalid";
        public const string BAD_CODE_CHALLENGE_METHOD = "transform algorithm {0} is not supported";
        public const string BAD_SOFTWARE_STATEMENT_SIGNATURE = "software statement signature is invalid";
        public const string BAD_GRANT_TYPE = "bad grant type";
        public const string BAD_EXTERNAL_AUTHENTICATION = "an error occured while trying to authenticate the user";
        public const string BAD_JWS_SOFTWARE_STATEMENT = "software statement is not a JWS token";
        public const string BAD_ISSUER_SOFTWARE_STATEMENT = "software statement issuer is not trusted";
        public const string BAD_USER_CREDENTIAL = "bad user credential";
        public const string BAD_CLIENT_CREDENTIAL = "bad client credential";
        public const string BAD_EXTERNAL_AUTHENTICATION_USER = "no identifier can be extracted from the external authentication provider";
        public const string BAD_CLIENT_GRANT_TYPE = "grant type {0} is not supported by the client";
        public const string BAD_CLIENT_ASSERTION_JWT = "client_assertion is not a valid JWT token";
        public const string BAD_CLIENT_ASSERTION_ENCRYPTED = "client_assertion cannot be encrypted (JWE)";
        public const string BAD_CLIENT_ASSERTION_DECRYPTION = "bad client assertion decryption";
        public const string BAD_CLIENT_ASSERTION_FORMAT = "bad client assertion format";
        public const string BAD_CLIENT_ASSERTION_SIGNATURE = "bad client assertion signature";
        public const string BAD_CLIENT_ASSERTION_ISSUER = "bad client assertion issuer";
        public const string BAD_CLIENT_ASSERTION_ALG = "the algorithm used by client assertion is not correct";
        public const string BAD_CLIENT_ASSERTION_AUDIENCES = "bad client assertion audiences";
        public const string BAD_CLIENT_ASSERTION_EXPIRED = "client assertion is expired";
        public const string BAD_CLAIM_TOKEN = "claim_token parameter is not a JWS token";
        public const string BAD_RESPONSE_TYPES = "response types {0} are not supported";
        public const string BAD_RESPONSE_TYPES_CLIENT = "response types {0} are not supported by the client";
        public const string BAD_ID_TOKEN_HINT_SIG = "signature of the id_token_hint is not correct";
        public const string BAD_ACCESS_TOKEN = "access token is not correct";
        public const string BAD_REDIRECT_URI = "redirect_uri {0} is not correct";
        public const string BAD_CLIENT_URI = "client uri {0} is not correct";
        public const string BAD_LOGO_URI = "logo uri {0} is not correct";
        public const string BAD_POLICY_URI = "policy uri {0} is not correct";
        public const string BAD_TOS_URI = "tos uri {0} is not correct";
        public const string BAD_JWKS_URI = "jwks uri {0} is not correct";
        public const string BAD_TOKEN = "bad token";
        public const string BAD_REFRESH_TOKEN = "bad refresh token";
        public const string BAD_AUTHORIZATION_CODE = "bad authorization code";
        public const string BAD_RESPONSE_TYPE = "response type must equals to 'code'";
        public const string BAD_RESPONSE_MODE = "response mode {0} is not supported";
        public const string BAD_SELF_SIGNED_CERTIFICATE = "the certificate is not correct";
        public const string BINDING_MESSAGE_MUST_NOT_EXCEED = "binding_message must not exceed {0} characters";
        public const string CLIENT_ASSERTION_TYPE_NOT_SUPPORTED = "client assertion type {0} is not supported";
        public const string CLIENT_ASSERTION_IS_MISSING = "client assertion is missing";
        public const string CLIENT_ASSERTION_TYPE_IS_UNEXPECTED = "unexpected client_assertion_type, must be equals to {0}";
        public const string CLIENT_ASSERTION_IS_NOT_SIGNED = "client assertion must be a signed JWT (JWS)";
        public const string CLIENT_ASSERTION_IS_NOT_ENCRYPTED = "client assertion must be encrypted JWT (JWE)";
        public const string CLIENT_ASSERTION_CANNOT_BE_DECRYPTED = "client assertion cannot be decryted by the client secret";
        public const string CLIENT_ASSERTION_NOT_SIGNED_BY_KNOWN_JWK = "client assertion is not signed by a known Json Web Key";
        public const string CLIENT_ID_CANNOT_BE_EXTRACTED_FROM_CLIENT_ASSERTION = "client_id cannot be extracted from client_assertion";
        public const string CLIENT_NOTIFICATION_TOKEN_MUST_NOT_EXCEED_1024 = "client_notification_token must not exceed 1024 characters";
        public const string CLIENT_NOTIFICATION_TOKEN_MUST_CONTAIN_AT_LEAST_128_BYTES = "client_notification_token must contains at least 128 bytes";
        public const string MISSING_PARAMETER = "missing parameter {0}";
        public const string MISSING_PARAMETERS = "missing parameters {0}";
        public const string MISSING_TOKEN = "missing token";
        public const string MISSING_RESPONSE_TYPES = "missing response types {0}";
        public const string MISSING_RESPONSE_TYPE = "valid response type must be passed for the grant type {0}";
        public const string MISSING_ACCESS_TOKEN = "access token is missing";
        public const string MISSING_USER_CODE = "the parameter user_code is missing";
        public const string MISSING_CLIENT_ID = "missing client_id";
        public const string MISSING_POST_LOGOUT_REDIRECT_URI = "the parameter post_logout_redirect_uri is missing";
        public const string MISSING_ID_TOKEN_HINT = "id_token_hint parameter is missing";
        public const string MISSING_RESPONSE_TYPE_CLAIM = "the response_type claim is missing";
        public const string MISSING_CLIENT_ID_CLAIM = "the client_id claim is missing";
        public const string MISSING_DPOP_PROOF = "the DPOP Proof is missing";
        public const string MISSING_SESSIONID = "the session identifier is missing";
        public const string UNSUPPORTED_USERINFO_SIGNED_RESPONSE_ALG = "userinfo_signed_response_alg is not supported";
        public const string UNSUPPORTED_TOKEN_ENCRYPTED_RESPONSE_ALG = "token_encrypted_response_alg is not supported";
        public const string UNSUPPORTED_IDTOKEN_ENCRYPTED_RESPONSE_ALG = "id_token_encrypted_response_alg is not supported";
        public const string UNSUPPORTED_IDTOKEN_ENCRYPTED_RESPONSE_ENC = "id_token_encrypted_response_enc is not supported";
        public const string UNSUPPORTED_USERINFO_ENCRYPTED_RESPONSE_ALG = "userinfo_encrypted_response_alg is not supported";
        public const string UNSUPPORTED_USERINFO_ENCRYPTED_RESPONSE_ENC = "userinfo_encrypted_response_enc is not supported";
        public const string UNSUPPORTED_REQUEST_OBJECT_SIGNING_ALG = "request_object_signing_alg is not supported";
        public const string UNSUPPORTED_REQUEST_OBJECT_ENCRYPTION_ALG = "request_object_encryption_alg is not supported";
        public const string UNSUPPORTED_REQUEST_OBJECT_ENCRYPTION_ENC = "request_object_encryption_enc is not supported";
        public const string UNSUPPORTED_TOKEN_ENCRYPTED_RESPONSE_ENC = "token_encrypted_response_enc is not supported";
        public const string UNSUPPORTED_TOKEN_SIGNED_RESPONSE_ALG = "token_signed_response_alg is not supported";
        public const string UNSUPPORTED_BC_AUTHENTICATION_REQUEST_SIGNING_ALG = "bc_authentication_request_signing_alg is not supported";
        public const string UNSUPPORTED_CREDENTIALS_FORMAT = "credential formats {0} are not supported";
        public const string UNSUPPORTED_SCOPES = "scopes {0} are not supported";
        public const string UNSUPPORTED_GRANT_TYPE = "grant type {0} is not supported";
        public const string UNSUPPORTED_GRANT_TYPES = "grant types {0} are not supported";
        public const string UNSUPPORTED_AUTHORIZATION_DETAILS_TYPES = "authorization details types {0} are not supported";
        public const string UNSUPPORTED_IDTOKEN_SIGNED_RESPONSE_ALG = "id_token_signed_response_alg is not supported";
        public const string UNSUPPORTED_CREDENTIAL_TYPES = "the credential offer doesn't support those credential types {0}";
        public const string UNSUPPORTED_AUTHORIZATION_SIGNED_RESPONSE_ALG = "authorization_signed_response_alg is not supported";
        public const string UNSUPPORTED_AUTHORIZATION_ENCRYPTED_RESPONSE_ALG = "authorization_encrypted_response_alg is not supported";
        public const string UNSUPPORTED_AUTHORIZATION_ENCRYPTED_RESPONSE_ENC = "authorization_encrypted_response_enc is not supported";
        public const string UNSUPPORTED_CREDENTIAL_TYPE = "the credential type {0} is not supported";
        public const string UNSUPPORTED_AMRS = "the authentication method references {0} are not supported";
        public const string REFRESH_TOKEN_NOT_ISSUED_BY_CLIENT = "refresh token has not been issued by the client";
        public const string NO_REGISTERED_REDIRECTURI = "no redirect uri has been registered";
        public const string NO_ESSENTIAL_ACR_IS_SUPPORTED = "no essential acr is supported";
        public const string DUPLICATE_JWKS = "jwks and jwks_uri parameters cannot be passed at the same time";
        public const string LOGIN_IS_REQUIRED = "login is required";
        public const string LOGIN_HINT_TOKEN_IS_EXPIRED = "login_hint_token has expired";
        public const string AUTHORIZATION_CODE_ALREADY_USED = "authorization code has already been used, all tokens previously issued have been revoked";
        public const string AUTHORIZATION_CODE_NOT_ISSUED_BY_CLIENT = "authorization code has not been issued by the client";
        public const string ACCESS_TOKEN_REJECTED = "access token has been rejected";
        public const string REFRESH_TOKEN_IS_EXPIRED = "refresh token is expired";
        public const string ACCESS_TOKEN_VALID_CLIENT = "access token can be used for the client '{0}' and not for '{1}'";
        public const string CLIENT_IDENTIFIER_MUST_BE_IDENTICAL = "client identifier must be identical";
        public const string CLIENT_IDENTIFIER_ALREADY_EXISTS = "client identifier {0} already exists";
        public const string CLIENT_SECRET_MUST_BE_IDENTICAL = "client secret must be identical";
        public const string NO_CLIENT_CERTIFICATE = "no client certificate";
        public const string CERTIFICATE_SUBJECT_INVALID = "certificate subject is invalid";
        public const string CERTIFICATE_SAN_DNS_INVALID = "certificate san DNS is invalid";
        public const string CERTIFICATE_SAN_EMAIL_INVALID = "certificate san EMAIL is invalid";
        public const string CERTIFICATE_SAN_IP_INVALID = "certificate san IP is invalid";
        public const string CERTIFICATE_IS_REQUIRED = "certificate is required";
        public const string CERTIFICATE_IS_NOT_TRUSTED = "certificate is not trusted";
        public const string CERTIFICATE_IS_NOT_SELF_SIGNED = "the certificate is not self signed";
        public const string REQUEST_OBJECT_IS_EXPIRED = "request object is expired";
        public const string REQUEST_OBJECT_BAD_AUDIENCE = "request object has bad audience";
        public const string REQUEST_DENIED = "The client is not authorized to have these permissions.";
        public const string REQUESTED_EXPIRY_MUST_BE_POSITIVE = "requested_expiry must be positive";
        public const string ONLY_HYBRID_WORKFLOWS_ARE_SUPPORTED = "only hybrid workflow are supported";
        public const string UNKNOWN_JSON_WEB_KEY = "unknown json web key '{0}'";
        public const string TOO_MANY_AUTH_REQUEST = "you tried too many times to get a token";
        public const string TOO_MANY_DPOP_HEADER = "too many DPoP parameters are passed in the header";
        public const string AUTH_REQUEST_EXPIRED = "the authorization request is expired";
        public const string REDIRECT_URI_CONTAINS_FRAGMENT = "the redirect_uri cannot contains fragment";
        public const string CLIENT_ID_CANNOT_BE_EXTRACTED = "client identifier cannot be extracted from the initial request";
        public const string SCOPE_ALREADY_EXISTS = "scope '{0}' already exists";
        public const string USER_ALREADY_EXISTS = "user '{0}' already exists";
        public const string NOT_SAME_REDIRECT_URI = "not the same redirect_uri";
        public const string ONLY_PINGORPOLL_MODE_CAN_BE_USED = "only ping or poll mode can be used to get tokens";
        public const string ONE_HINT_MUST_BE_PASSED = "only one hint can be passed in the request";
        public const string AUTH_REQUEST_CLIENT_NOT_AUTHORIZED = "the client is not authorized to use the auth_req_id";
        public const string AUTH_REQUEST_BAD_AUDIENCE = "the request doesn't contain correct audience";
        public const string AUTH_REQUEST_NO_AUDIENCE = "the request doesn't contain audience";
        public const string AUTH_REQUEST_NO_ISSUER = "the request doesn't contain issuer";
        public const string AUTH_REQUEST_BAD_ISSUER = "the request doesn't contain correct issuer";
        public const string AUTH_REQUEST_NO_EXPIRATION = "the request doesn't contain expiration time";
        public const string AUTH_REQUEST_NO_JTI = "the request doesn't contain jti";
        public const string AUTH_REQUEST_NO_NBF = "the request doesn't contain nbf";
        public const string AUTH_REQUEST_BAD_NBF = "the request cannot be received before '{0}'";
        public const string AUTH_REQUEST_NO_IAT = "the request doesn't contain iat";
        public const string AUTH_REQUEST_MAXIMUM_LIFETIME = "the maximum lifetime of the request is '{0}' seconds";
        public const string AUTH_REQUEST_NOT_CONFIRMED = "the authorization request has not been confirmed";
        public const string AUTH_REQUEST_ALG_NOT_VALID = "the request must be signed with '{0}' algorithm";
        public const string AUTH_REQUEST_IS_EXPIRED = "the request is expired";
        public const string AUTH_REQUEST_REJECTED = "the authorization request has been rejected";
        public const string AUTH_REQUEST_SENT = "the authorization request is finished";
        public const string AUTH_REQUEST_NOT_AUTHORIZED_TO_REJECT = "you're not authorized to reject the authorization request";
        public const string CONTENT_TYPE_NOT_SUPPORTED = "the content-type is not correct";
        public const string JWT_MUST_BE_ENCRYPTED = "JWT must be encrypted with the algorithm {0}";
        public const string JWT_MUST_BE_SIGNED = "JWT must be signed with the algorithm {0}";
        public const string JWT_CANNOT_BE_ENCRYPTED = "JWT cannnot be encrypted";
        public const string JWT_CANNOT_BE_DECRYPTED = "An unexcepted error occured while trying to decrypt the JWT";
        public const string JWT_BAD_SIGNATURE = "JWT doesn't have a correct signature";
        public const string CANNOT_GENERATE_PAIRWISE_SUBJECT_MORE_THAN_ONE_REDIRECT_URLS = "pairwise subject cannot be generated because the sectore_identifier_uri is empty and the client contains more than one redirect_uri";
        public const string CANNOT_GENERATE_PAIRWISE_SUBJECT_BECAUSE_NO_SECTOR_IDENTIFIER = "pairwise subject cannot be generated because the sector_identifier_uri is empty and there is no redirect_uri";
        public const string POLLING_DEVICE_ALREADY_REGISTERED = "only one polling device can be registrered";
        public const string POLLING_DEVICE_NOT_REGISTERED = "polling device is not registered";
        public const string GRANT_ID_CANNOT_BE_SPECIFIED = "grant_id cannot be specified because the grant_management_action is equals to create";
        public const string BC_AUTHORIZE_NOT_PENDING = "the back channel authorization is not in pending";
        public const string UNEXPECTED_REQUEST_URI_PARAMETER = "the request cannot contains request_uri";
        public const string REQUEST_URI_IS_REQUIRED = "the request_uri is required";
        public const string REQUEST_URI_IS_INVALID = "the request_uri is invalid";
        public const string AUTHORIZATION_DETAILS_TYPE_REQUIRED = "the authorization_details type is required";
        public const string GRANT_IS_NOT_ACCEPTED = "grant is not accepted";
        public const string USER_EXISTS = "the user {0} already exists";
        public const string CONTRACT_ALREADY_DEPLOYED = "contract is already deployed";
        public const string NO_CONTRACT = "there is no contract";
        public const string ACR_WITH_SAME_NAME_EXISTS = "an acr with the same name already exists";
        public const string AUTHSCHEMEPROVIDER_WITH_SAME_NAME_EXISTS = "an authentication scheme provider with the same name already exists";
        public const string NOT_WELL_FORMED_DPOP_TOKEN = "the DPoP proof must be a Json Web Token";
        public const string USE_DPOP_NONCE = "Authorization Server required nonce in DPoP proof";
        public const string DPOP_JKT_MISMATCH = "there is a mismatch between the dpop_jkt and the DPoP proof";
        public const string USER_NOT_AUTHENTICATED = "you're not authenticated";
        public const string INACTIVE_SESSION = "the session is not active";
    }
}