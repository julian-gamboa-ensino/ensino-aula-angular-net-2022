﻿using System;
using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Dependency;
using AbpCoreEf6Sample.Authentication.JwtBearer;
using AbpCoreEf6Sample.Configuration;
using AbpCoreEf6Sample.Identity;
using AbpCoreEf6Sample.Web.Resources;
using AbpCoreEf6Sample.Web.Startup;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Effort;
using System.Data.Common;

namespace AbpCoreEf6Sample.Web.Tests
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);
            
            services.AddScoped<IWebResourceManager, WebResourceManager>();

            //Configure Abp and Dependency Injection
            return services.AddAbp<AbpCoreEf6SampleWebTestModule>(options =>
            {
                options.SetupTest();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            UseInMemoryDb(app.ApplicationServices);

            app.UseAbp(); //Initializes ABP framework.

            app.UseExceptionHandler("/Error");

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void UseInMemoryDb(IServiceProvider serviceProvider)
        {
            var _hostDb = DbConnectionFactory.CreateTransient();
            var iocManager = serviceProvider.GetRequiredService<IIocManager>();

            iocManager.IocContainer.Register(
               Component.For<DbConnection>()
                   .UsingFactoryMethod(() => _hostDb)
                   .LifestyleSingleton()
               );
        }
    }
}