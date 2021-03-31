using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PSC.Infrastructures.Hubs;
using PSC.Services.Imports;
using PSC.Services.Imports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Code.Processes
{
    /// <summary>
    /// Class ImportExcelProcess.
    /// </summary>
    public class ImportExcelProcessBase
    {
        private readonly ImportExcel _excel;
        private readonly IHubContext<NotificationHub> _hubContext;
        protected readonly ILogger<ImportExcelProcessBase> _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportExcelProcessBase" /> class.
        /// </summary>
        /// <param name="excel">The excel.</param>
        /// <param name="hubContext">The hub context.</param>
        /// <param name="log">The log.</param>
        public ImportExcelProcessBase(ImportExcel excel, IHubContext<NotificationHub> hubContext, 
            ILogger<ImportExcelProcessBase> log)
        {
            _excel = excel;
            _hubContext = hubContext;
            _log = log;
        }

        public virtual async Task Start(string username, string filename)
        {
        }

        public async Task ProcessComplete(string username, string filename, string title, string message)
        {
            _log.LogInformation($"Process complete for {filename}");
            await _hubContext.Clients.All.SendAsync("Send", username, title, message);
        }

        /// <summary>
        /// Reads the data.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="rowDef">The row definition.</param>
        /// <returns>System.ValueTuple&lt;System.Boolean, List&lt;System.String&gt;, DataGrid&gt;.</returns>
        protected (bool IsValid, List<string> Errors, DataGrid Data) ReadData(string filename, RowDef rowDef)
        {
            _log.LogDebug("Starting validation file " + filename);

            bool rtn = true;
            List<string> errs = new List<string>();

            DataGrid g = _excel.ReadToGrid(filename);
            if (g.Success)
            {
                var (IsValid, errors) = _excel.ValidateHeader(g, rowDef);

                rtn = IsValid;
                if (errors.Count > 0)
                    errs = errors;
            }

            _log.LogDebug($"Validation file {filename} completed");
            return (rtn, errs, g);
        }
    }
}