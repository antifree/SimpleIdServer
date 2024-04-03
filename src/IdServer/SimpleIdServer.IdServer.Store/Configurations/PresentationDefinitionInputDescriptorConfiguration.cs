﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleIdServer.IdServer.Domains;

namespace SimpleIdServer.IdServer.Store.Configurations;

public class PresentationDefinitionInputDescriptorConfiguration : IEntityTypeConfiguration<PresentationDefinitionInputDescriptor>
{
    public void Configure(EntityTypeBuilder<PresentationDefinitionInputDescriptor> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p => p.Format).WithOne().OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.Constraints).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}
