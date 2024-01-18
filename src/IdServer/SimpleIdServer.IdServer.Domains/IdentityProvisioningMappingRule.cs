﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SimpleIdServer.IdServer.Domains;

public class IdentityProvisioningMappingRule : IProvisioningMappingRule
{
    public string Id { get; set; } = null!;
    public string From { get; set; } = null!;
    public MappingRuleTypes MapperType { get; set; }
    public string? TargetUserAttribute { get; set; } = null;
    public string? TargetUserProperty { get; set; } = null;
    public bool HasMultipleAttribute { get; set; } = false;
    public IdentityProvisioningMappingUsage Usage { get; set; } = IdentityProvisioningMappingUsage.USER;
    public IdentityProvisioningDefinition IdentityProvisioningDefinition { get; set; } = null!;
}

public enum IdentityProvisioningMappingUsage
{
    USER = 0,
    GROUP = 1
}