﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Stores;

namespace SimpleIdServer.IdServer.Store.EF;

public class ConfigurationDefinitionStore : IConfigurationDefinitionStore
{
    private readonly StoreDbContext _dbContext;

    public ConfigurationDefinitionStore(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<ConfigurationDefinition> Query() => _dbContext.Definitions;
}