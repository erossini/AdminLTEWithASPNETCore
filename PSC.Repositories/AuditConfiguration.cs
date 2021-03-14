using Audit.Core;
using Microsoft.Extensions.DependencyInjection;
using PSC.Domain;
using PSC.Domain.Audit;
using PSC.Domain.Audit.CommonTables;
using PSC.Domain.CommonTables;
using PSC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Repositories
{
    /// <summary>
    /// Class AuditConfiguration.
    /// </summary>
    public static class AuditConfiguration
    {
        /// <summary>
        /// Global Audit configuration
        /// </summary>
        public static IServiceCollection ConfigureAudit(this IServiceCollection serviceCollection, string connString)
        {
            #region Use this when you have another table for audit
            Audit.Core.Configuration.Setup()
                .UseEntityFramework(ef => ef.AuditTypeExplicitMapper(m => m
                    .Map<AzureCost, AuditAzureCost>()
                    .Map<AzureCostImport, AuditAzureCostImport>()
                    .Map<AzureCostImportLog, AuditAzureCostImportLog>()
                    .Map<AzureCategory, AuditAzureCategory>()
                    .Map<AzureLocation, AuditAzureLocation>()
                    .Map<AzureResource, AuditAzureResource>()
                    .Map<AzureResourceGroup, AuditAzureResourceGroup>()
                    .Map<AzureSubcategory, AuditAzureSubcategory>() 
                    .Map<Country, AuditCountry>()
                    .Map<Message, AuditMessage>()
                    .AuditEntityAction<IAudit>((evt, entry, auditEntity) =>
                    {
                        auditEntity.AuditDate = DateTime.UtcNow;
                        auditEntity.UserName = evt.Environment.UserName;
                        auditEntity.AuditAction = entry.Action; // Insert, Update, Delete
                    })));
            #endregion

            return serviceCollection;
        }
    }
}
