using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MultiTenancyExample.Web.Middleware;

namespace MultiTenancyExample.Web.Data
{
    internal static class DbContextOptionsFactory
    {
        public static DbContextOptions<BloggingContext> CreateForTenantUsingClaims(IServiceProvider serviceProvider)
        {
            var tenantConnectionString = GetTenantConnectionString(serviceProvider);
            var dbContextOptions = CreateDbContextOptions(serviceProvider, tenantConnectionString);

            return dbContextOptions;
        }

        private static DbContextOptions<BloggingContext> CreateDbContextOptions(IServiceProvider serviceProvider, string tenantConnectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>()
                .UseInMemoryDatabase(tenantConnectionString)
                .UseLoggerFactory(serviceProvider.GetService<ILoggerFactory>());

            return optionsBuilder.Options;
        }

        private static string GetTenantConnectionString(IServiceProvider serviceProvider)
        {
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var companyIdClaim = httpContextAccessor.HttpContext.User.FindFirst(MultitenancyExampleClaimNames.CompanyId);

            return companyIdClaim.Value;
        }
    }
}