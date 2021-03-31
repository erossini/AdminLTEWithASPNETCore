using Microsoft.Extensions.Logging;
using PSC.Providers.CommonTables;
using PSC.Providers.Tables;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Providers
{
    public class DataProviders
    {
        private PSCContext _db;
        private ILogger _log;

        public DataProviders(PSCContext db, ILogger<DataProviders> log)
        {
            _db = db;
            _log = log;

            AzureCost = new AzureCostProvider(_db, _log);
            AzureCostImport = new AzureCostImportProvider(_db, _log);
            AzureCostImportLog = new AzureCostImportLogProvider(_db, _log);

            #region Common table
            AzureCategory = new AzureCategoryProvider(_db, _log);
            AzureLocation = new AzureLocationProvider(_db, _log);
            AzureResourceGroup = new AzureResourceGroupProvider(_db, _log);
            AzureResource = new AzureResourceProvider(_db, _log);
            AzureSubcategory = new AzureSubcategoryProvider(_db, _log);
            Countries = new CountriesProvider(_db);
            #endregion
        }

        public AzureCostProvider AzureCost { get; }
        public AzureCostImportProvider AzureCostImport { get; set; }
        public AzureCostImportLogProvider AzureCostImportLog { get; set; }

        #region Common tables
        public AzureCategoryProvider AzureCategory { get; }
        public AzureLocationProvider AzureLocation { get; }
        public AzureResourceGroupProvider AzureResourceGroup { get; }
        public AzureResourceProvider AzureResource { get; }
        public AzureSubcategoryProvider AzureSubcategory { get; }
        public CountriesProvider Countries { get; set; }
        #endregion
    }
}
