using AdminLTEWithASPNETCore.Models.Imports;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Extensions;
using PSC.Infrastructures.Hubs;
using PSC.Persistence.Interfaces.CommonTables;
using PSC.Persistence.Interfaces.Tables;
using PSC.Services.Imports;
using PSC.Services.Imports.Models;
using System.IO;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Code.Processes
{
    public class ImportAzureProcess : ImportExcelProcessBase
    {
        private readonly IAzureCategoryRepository _azureCategory;
        private readonly IAzureCostRepository _azureCost;
        private readonly IAzureCostImportRepository _azureCostImport;
        private readonly IAzureCostImportLogRepository _azureCostImportLog;
        private readonly IAzureLocationRepository _azureLocation;
        private readonly IAzureResourceRepository _azureResource;
        private readonly IAzureResourceGroupRepository _azureResourceGroup;
        private readonly IAzureSubcategoryRepository _azureSubcategory;

        public ImportAzureProcess(ImportExcel excel, IHubContext<NotificationHub> hubContext,
            IAzureCategoryRepository azureCategory,
            IAzureCostRepository azureCost,
            IAzureCostImportRepository azureCostImport,
            IAzureCostImportLogRepository azureCostImportLog,
            IAzureLocationRepository azureLocation,
            IAzureResourceRepository azureResource,
            IAzureResourceGroupRepository azureResourceGroup,
            IAzureSubcategoryRepository azureSubcategory,
            ILogger<ImportAzureProcess> log) : base(excel, hubContext, log)
        {
            _azureCategory = azureCategory;
            _azureCost = azureCost;
            _azureCostImport = azureCostImport;
            _azureCostImportLog = azureCostImportLog;
            _azureLocation = azureLocation;
            _azureResource = azureResource;
            _azureResourceGroup = azureResourceGroup;
            _azureSubcategory = azureSubcategory;
        }

        public override async Task Start(string username, string filename)
        {
            _log.LogDebug($"User {username} started the import for {filename}");

            long id = _azureCostImport.GetIdByNameAsync(Path.GetFileName(filename));

            var (IsValid, Errors, Data) = ReadData(filename, FileStructure.AzureReportStructure);
            if (IsValid)
            {
                await ImportFile(Data, id);
                await ProcessComplete(username, filename, "File imported", $"The file {Path.GetFileName(filename)} has been imported. See it on Import > View all imports");

                await _azureCostImportLog.AddAsync(new PSC.Domain.AzureCostImportLog()
                {
                    AzureCostImportId = id,
                    LogType = PSC.Domain.Enums.LogType.EndProcess,
                    Message = "Import completed",
                    CreatedBy = CommonConst.SystemUser
                });
            }
        }

        public async Task ImportFile(DataGrid data, long fileId)
        {
            _log.LogDebug("Read the file and save in the database");

            int totalRecords = data.Rows.Count;
            int totalImports = 0;

            foreach (var row in data.Rows)
            {
                _log.LogDebug("Start a new row");
                var cost = new AzureCost();
                cost.AzureCostImportId = fileId;
                if (row.ContainsKey("Resource")) cost.AzureResource = await _azureResource.CreateIfNotExist(row["Resource"]);
                if (row.ContainsKey("Location")) cost.AzureLocation = await _azureLocation.CreateIfNotExist(row["Location"]);
                if (row.ContainsKey("Resource Group")) cost.AzureResourceGroup = await _azureResourceGroup.CreateIfNotExist(row["Resource Group"]);
                if (row.ContainsKey("Category")) cost.AzureCategory = await _azureCategory.CreateIfNotExist(row["Category"]);
                if (row.ContainsKey("Subcategory")) cost.AzureSubcategory = await _azureSubcategory.CreateIfNotExist(row["Subcategory"]);
                if (row.ContainsKey("Quantity")) cost.Quantity = row["Quantity"].IsDecimal();
                if (row.ContainsKey("Cost (£)")) cost.Cost = row["Cost (£)"].IsDecimal();

                await _azureCost.AddAsync(cost);
                totalImports++;

                _log.LogDebug($"Import progress {totalImports}/{totalRecords}");
            }

            _log.LogInformation($"Import completed: {totalImports}/{totalRecords}");
            await _azureCostImportLog.AddAsync(new PSC.Domain.AzureCostImportLog()
            {
                AzureCostImportId = fileId,
                LogType = PSC.Domain.Enums.LogType.Information,
                Message = $"Import completed: {totalImports}/{totalRecords}",
                CreatedBy = CommonConst.SystemUser
            });
        }
    }
}