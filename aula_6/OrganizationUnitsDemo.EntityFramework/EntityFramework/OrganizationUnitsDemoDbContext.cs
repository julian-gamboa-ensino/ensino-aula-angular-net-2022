﻿using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using OrganizationUnitsDemo.Authorization.Roles;
using OrganizationUnitsDemo.MultiTenancy;
using OrganizationUnitsDemo.Products;
using OrganizationUnitsDemo.Users;

namespace OrganizationUnitsDemo.EntityFramework
{
    public class OrganizationUnitsDemoDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public IDbSet<Product> Products { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public OrganizationUnitsDemoDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in OrganizationUnitsDemoDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of OrganizationUnitsDemoDbContext since ABP automatically handles it.
         */
        public OrganizationUnitsDemoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public OrganizationUnitsDemoDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
