﻿using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public class AbpDbContextConfigurationContext
    {
        public string ConnectionString { get; }

        public string DatabaseName { get; }

        public DbContextOptionsBuilder DbContextOptions { get; protected set; }

        public AbpDbContextConfigurationContext(string connectionString, [CanBeNull] string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
            DbContextOptions = new DbContextOptionsBuilder();
        }
    }

    public class AbpDbContextConfigurationContext<TDbContext> : AbpDbContextConfigurationContext
        where TDbContext : AbpDbContext<TDbContext>
    {
        public new DbContextOptionsBuilder<TDbContext> DbContextOptions => (DbContextOptionsBuilder<TDbContext>)base.DbContextOptions;

        public AbpDbContextConfigurationContext(string connectionString, [CanBeNull] string databaseName)
            : base(connectionString, databaseName)
        {
            base.DbContextOptions = new DbContextOptionsBuilder<TDbContext>();
        }
    }
}