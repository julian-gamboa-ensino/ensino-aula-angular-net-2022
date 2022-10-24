﻿using System.Data.Entity;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFramework;

namespace AbpCoreEf6Sample.EntityFramework
{
    [DependsOn(
        typeof(AbpCoreEf6SampleCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkModule))]
    public class AbpCoreEf6SampleEntityFrameworkModule : AbpModule
    {
        public bool SkipSetInitializer = false;

        public override void PreInitialize()
        {
            if (!SkipSetInitializer)
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<AbpCoreEf6SampleDbContext>());
            }

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreEf6SampleEntityFrameworkModule).GetAssembly());
        }
    }
}
