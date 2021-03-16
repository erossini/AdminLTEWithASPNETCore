using AdminLTEWithASPNETCore.Models.Imports;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Extensions;
using PSC.Infrastructures.Hubs;
using PSC.Providers;
using PSC.Services.Imports;
using PSC.Services.Imports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Code.Processes
{
    public class ImportAzureProcess : ImportExcelProcessBase
    {
        private DataProviders _providers;

        public ImportAzureProcess(ImportExcel excel, IHubContext<NotificationHub> hubContext,
            DataProviders dataProviders, ILogger<ImportAzureProcess> log) : base(excel, hubContext, log)
        {
            _providers = dataProviders;
        }

        public override async Task Start(string username, string filename)
        {
            _log.LogDebug($"User {username} started the import for {filename}");

            long id = _providers.AzureCostImport.GetIdByNameAsync(Path.GetFileName(filename));

            var (IsValid, Errors, Data) = ReadData(filename, FileStructure.AzureReportStructure);
            if (IsValid)
            {
                await ImportFile(Data, id);
                await ProcessComplete(username, filename, "File imported", $"The file {Path.GetFileName(filename)} has been imported. See it on Import > View all imports");

                await _providers.AzureCostImportLog.InsertAsync(new PSC.Domain.AzureCostImportLog()
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
                if (row.ContainsKey("Resource")) cost.AzureResource = await _providers.AzureResource.CreateIfNotExist(row["Resource"]);
                if (row.ContainsKey("Location")) cost.AzureLocation = await _providers.AzureLocation.CreateIfNotExist(row["Location"]);
                if (row.ContainsKey("Resource Group")) cost.AzureResourceGroup = await _providers.AzureResourceGroup.CreateIfNotExist(row["Resource Group"]);
                if (row.ContainsKey("Category")) cost.AzureCategory = await _providers.AzureCategory.CreateIfNotExist(row["Category"]);
                if (row.ContainsKey("Subcategory")) cost.AzureSubcategory = await _providers.AzureSubcategory.CreateIfNotExist(row["Subcategory"]);
                if (row.ContainsKey("Quantity")) cost.Quantity = row["Quantity"].IsDecimal();
                if (row.ContainsKey("Cost (£)")) cost.Cost = row["Cost (£)"].IsDecimal();

                long id = await _providers.AzureCost.InsertAsync(cost);
                totalImports++;

                _log.LogDebug($"Import progress {totalImports}/{totalRecords}");
            }

            _log.LogInformation($"Import completed: {totalImports}/{totalRecords}");
            await _providers.AzureCostImportLog.InsertAsync(new PSC.Domain.AzureCostImportLog()
            {
                AzureCostImportId = fileId,
                LogType = PSC.Domain.Enums.LogType.Information,
                Message = $"Import completed: {totalImports}/{totalRecords}",
                CreatedBy = CommonConst.SystemUser
            });
        }
    }
}