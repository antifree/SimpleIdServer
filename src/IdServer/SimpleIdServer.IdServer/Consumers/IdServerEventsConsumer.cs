﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Events;
using SimpleIdServer.IdServer.ExternalEvents;
using SimpleIdServer.IdServer.Store;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Consumers
{
    public class IdServerEventsConsumer : IConsumer<AuthorizationFailureEvent>, IConsumer<AuthorizationSuccessEvent>,
        IConsumer<ClientAuthenticationFailureEvent>, IConsumer<ClientAuthenticationSuccessEvent>,
        IConsumer<ClientRegisteredFailureEvent>, IConsumer<ClientRegisteredSuccessEvent>,
        IConsumer<ConsentGrantedEvent>, IConsumer<ConsentRevokedEvent>,
        IConsumer<TokenIntrospectionFailureEvent>, IConsumer<TokenIntrospectionSuccessEvent>,
        IConsumer<TokenIssuedFailureEvent>, IConsumer<TokenIssuedSuccessEvent>,
        IConsumer<TokenRevokedFailureEvent>, IConsumer<TokenRevokedSuccessEvent>,
        IConsumer<UserInfoFailureEvent>, IConsumer<UserInfoSuccessEvent>,
        IConsumer<UserLoginSuccessEvent>, IConsumer<UserLoginFailureEvent>, IConsumer<UserLogoutSuccessEvent>,
        IConsumer<PushedAuthorizationRequestSuccessEvent>, IConsumer<PushedAuthorizationRequestFailureEvent>,
        IConsumer<ImportUsersSuccessEvent>, IConsumer<ExtractRepresentationsFailureEvent>,
        IConsumer<ExtractRepresentationsSuccessEvent>, IConsumer<AddUserSuccessEvent>, IConsumer<RemoveUserSuccessEvent>,
        IConsumer<DeviceAuthorizationSuccessEvent>, IConsumer<DeviceAuthorizationFailureEvent>
    {
        private readonly IServiceProvider _serviceProvider;

        public IdServerEventsConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<AuthorizationFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Authorization Failed",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ClientId = context.Message.ClientId,
                    RequestJSON = context.Message.RequestJSON,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<AuthorizationSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Authorization Success",
                    CreateDateTime = DateTime.UtcNow,
                    ClientId = context.Message.ClientId,
                    RequestJSON = context.Message.RequestJSON,
                    RedirectUrl = context.Message.RedirectUrl,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ClientAuthenticationSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Client Authentication Success",
                    CreateDateTime = DateTime.UtcNow,
                    ClientId = context.Message.ClientId,
                    AuthMethod = context.Message.AuthMethod,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ClientRegisteredSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Client Registration Success",
                    CreateDateTime = DateTime.UtcNow,
                    RequestJSON = context.Message.RequestJSON,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ConsentRevokedEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Consent Revoked",
                    ClientId = context.Message.ClientId,
                    Scopes = context.Message.Scopes == null ? new string[0] : context.Message.Scopes.ToArray(),
                    Claims = context.Message.Claims?.ToArray(),
                    CreateDateTime = DateTime.UtcNow,
                    UserName = context.Message.UserName,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<UserLoginSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "User Login Success",
                    CreateDateTime = DateTime.UtcNow,
                    UserName = context.Message.UserName,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<UserLoginFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "User Login Failed",
                    CreateDateTime = DateTime.UtcNow,
                    UserName = context.Message.Login,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ClientRegisteredFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Client Registration Failed",
                    CreateDateTime = DateTime.UtcNow,
                    RequestJSON = context.Message.RequestJSON,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ClientAuthenticationFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Client Authentication Failed",
                    ClientId = context.Message.ClientId,
                    AuthMethod = context.Message.AuthMethod,
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = true
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<TokenIntrospectionFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Token Introspection Failed",
                    CreateDateTime = DateTime.UtcNow,
                    ClientId = context.Message.ClientId,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ConsentGrantedEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Consent Granted",
                    UserName = context.Message.UserName,
                    ClientId = context.Message.ClientId,
                    Scopes = context.Message.Scopes == null ? new string[0] : context.Message.Scopes.ToArray(),
                    Claims = context.Message.Claims?.ToArray(),
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<TokenIssuedFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Token Issued Failed",
                    Scopes = context.Message.Scopes == null ? new string[0] : context.Message.Scopes.ToArray(),
                    ClientId = context.Message.ClientId,
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<TokenIntrospectionSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Token Introspection Success",
                    ClientId = context.Message.ClientId,
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<TokenIssuedSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Token Issued Success",
                    ClientId = context.Message.ClientId,
                    Scopes = context.Message.Scopes == null ? new string[0] : context.Message.Scopes.ToArray(),
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<TokenRevokedSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Token Revoked Success",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<TokenRevokedFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Token Revoked Failure",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<UserInfoFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    ClientId = context.Message.ClientId,
                    UserName = context.Message.UserName,
                    Scopes = context.Message.Scopes == null ? new string[0] : context.Message.Scopes.ToArray(),
                    Description = "UserInfo Failure",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<UserInfoSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    ClientId = context.Message.ClientId,
                    UserName = context.Message.UserName,
                    Scopes = context.Message.Scopes == null ? new string[0] : context.Message.Scopes.ToArray(),
                    Description = "UserInfo Success",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<UserLogoutSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "UserInfo Logout",
                    UserName = context.Message.UserName,
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<PushedAuthorizationRequestFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Pushed Authorization Failed",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ClientId = context.Message.ClientId,
                    RequestJSON = context.Message.RequestJSON,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<PushedAuthorizationRequestSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Pushed Authorization Success",
                    CreateDateTime = DateTime.UtcNow,
                    ClientId = context.Message.ClientId,
                    RequestJSON = context.Message.RequestJSON,
                    RedirectUrl = context.Message.RedirectUrl,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ImportUsersSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = $"{context.Message.NbUsers} users have been imported",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ExtractRepresentationsSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = $"Extract {context.Message.NbRepresentations} users from {context.Message.IdentityProvisioningName}",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<ExtractRepresentationsFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = $"Fail to extract users from {context.Message.IdentityProvisioningName}",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    ErrorMessage = context.Message.ErrorMessage,
                    IsError = true
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<AddUserSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = $"User with the name '{context.Message.Name}' has been added",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false,
                    RequestJSON = JsonSerializer.Serialize(context.Message)
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<RemoveUserSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = $"User with the name '{context.Message.Name}' has been removed",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<DeviceAuthorizationSuccessEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Device Authorization Success",
                    CreateDateTime = DateTime.UtcNow,
                    ClientId = context.Message.ClientId,
                    RequestJSON = context.Message.RequestJSON,
                    Realm = context.Message.Realm,
                    IsError = false
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }

        public async Task Consume(ConsumeContext<DeviceAuthorizationFailureEvent> context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var auditEventRepository = scope.ServiceProvider.GetRequiredService<IAuditEventRepository>();
                var auditEvt = new AuditEvent
                {
                    Id = Guid.NewGuid().ToString(),
                    EventName = context.Message.EventName,
                    Description = "Device Authorization Failed",
                    CreateDateTime = DateTime.UtcNow,
                    Realm = context.Message.Realm,
                    IsError = true,
                    ClientId = context.Message.ClientId,
                    RequestJSON = context.Message.RequestJSON,
                    ErrorMessage = context.Message.ErrorMessage
                };
                auditEventRepository.Add(auditEvt);
                await auditEventRepository.SaveChanges(CancellationToken.None);
            }
        }
    }
}