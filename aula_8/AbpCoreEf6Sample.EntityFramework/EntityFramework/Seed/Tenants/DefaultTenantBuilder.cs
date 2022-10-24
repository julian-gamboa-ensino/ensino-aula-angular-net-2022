﻿using System.Linq;
using Abp.MultiTenancy;
using AbpCoreEf6Sample.Editions;
using AbpCoreEf6Sample.MultiTenancy;

namespace AbpCoreEf6Sample.EntityFramework.Seed.Tenants
{
    public class DefaultTenantBuilder
    {
        private readonly AbpCoreEf6SampleDbContext _context;

        public DefaultTenantBuilder(AbpCoreEf6SampleDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultTenant();
        }

        private void CreateDefaultTenant()
        {
            // Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == AbpTenantBase.DefaultTenantName);
            if (defaultTenant == null)
            {
                defaultTenant = new Tenant(AbpTenantBase.DefaultTenantName, AbpTenantBase.DefaultTenantName);

                var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
                if (defaultEdition != null)
                {
                    defaultTenant.EditionId = defaultEdition.Id;
                }

                _context.Tenants.Add(defaultTenant);
                _context.SaveChanges();
            }
        }
    }
}
