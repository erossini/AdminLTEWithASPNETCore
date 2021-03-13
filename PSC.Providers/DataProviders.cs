using Microsoft.Extensions.Logging;
using PSC.Providers.CommonTables;
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

            #region Common table
            AzureCategory = new AzureCategoryProvider(_db);
            AzureLocation = new AzureLocationProvider(_db);
            AzureResourceGroup = new AzureResourceGroupProvider(_db);
            AzureResource = new AzureResourceProvider(_db);
            AzureSubcategory = new AzureSubcategoryProvider(_db);
            #endregion
        }

        public AzureCostProvider AzureCost { get; }

        #region Common tables
        public AzureCategoryProvider AzureCategory { get; }
        public AzureLocationProvider AzureLocation { get; }
        public AzureResourceGroupProvider AzureResourceGroup { get; }
        public AzureResourceProvider AzureResource { get; }
        public AzureSubcategoryProvider AzureSubcategory { get; }
        #endregion
    }
}
