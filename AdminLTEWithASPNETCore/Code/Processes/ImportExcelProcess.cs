using Microsoft.AspNetCore.SignalR;
using PSC.Infrastructures.Hubs;
using PSC.Services.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Code.Processes
{
    /// <summary>
    /// Class ImportExcelProcess.
    /// </summary>
    public class ImportExcelProcess
    {
        private readonly ImportExcel _excel;
        private readonly IHubContext<NotificationHub> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportExcelProcess"/> class.
        /// </summary>
        /// <param name="excel">The excel.</param>
        /// <param name="hubContext">The hub context.</param>
        public ImportExcelProcess(ImportExcel excel, IHubContext<NotificationHub> hubContext)
        {
            _excel = excel;
            _hubContext = hubContext;
        }

        public async Task Start(string username, string filename)
        {
            await _hubContext.Clients.All.SendAsync("Send", username, "File imported!", "The file ... has been imported in the database.");
        }
    }
}
