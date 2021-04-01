using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSC.Persistence.Interfaces;
using PSC.Persistence.Interfaces.CommonTables;
using PSC.Persistence.Interfaces.Tables;
using PSC.Persistence.Repositories;
using PSC.Persistence.Repositories.CommonTables;
using PSC.Persistence.Repositories.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var cnnString = configuration.GetConnectionString("PSCContextConnection");
            services.AddDbContext<PSCContext>(options =>
                options.UseSqlServer(cnnString));
            services.ConfigureAudit(cnnString);

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            #region Common Tables
            services.AddScoped<IAzureCategoryRepository, AzureCategoryRepository>();
            services.AddScoped<IAzureLocationRepository, AzureLocationRepository>();
            services.AddScoped<IAzureResourceRepository, AzureResourceRepository>();
            services.AddScoped<IAzureResourceGroupRepository, AzureResourceGroupRepository>();
            services.AddScoped<IAzureSubcategoryRepository, AzureSubcategoryRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            #endregion

            services.AddScoped<IAzureCostRepository, AzureCostRepository>();
            services.AddScoped<IAzureCostImportRepository, AzureCostImportRepository>();
            services.AddScoped<IAzureCostImportLogRepository, AzureCostImportLogRepository>();

            return services;
        }
    }
}
