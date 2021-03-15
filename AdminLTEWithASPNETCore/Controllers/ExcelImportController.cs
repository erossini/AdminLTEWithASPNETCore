using AdminLTEWithASPNETCore.Attributes;
using AdminLTEWithASPNETCore.Code.Processes;
using AdminLTEWithASPNETCore.Enums.Components.Timeline;
using AdminLTEWithASPNETCore.Models.Controllers;
using AdminLTEWithASPNETCore.Models.Imports;
using AdminLTEWithASPNETCore.Models.UI.CommonTables;
using AdminLTEWithASPNETCore.Services;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSC.Domain.Enums;
using PSC.Providers;
using PSC.Services.AspNetCore;
using PSC.Services.AspNetCore.Models.Responses;
using PSC.Services.Imports;
using PSC.Services.Imports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers
{
    public class ExcelImportController : Controller
    {
        private readonly DataProviders _providers;
        private readonly IWebHostEnvironment _environment;
        private readonly ImportExcel _excel;
        private readonly ImportAzureProcess _process;
        private readonly UploadFiles _upload;

        public ExcelImportController(DataProviders providers, IWebHostEnvironment environment, ImportExcel excel,
            ImportAzureProcess process, UploadFiles upload)
        {
            _providers = providers;
            _environment = environment;
            _excel = excel;
            _process = process;
            _upload = upload;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadExcel(List<IFormFile> postedFiles)
        {
            var filename = Path.GetFileName(postedFiles.FirstOrDefault().FileName);
            var extension = Path.GetExtension(postedFiles.FirstOrDefault().FileName);
            if (extension.IndexOf("xls") == -1) return Content("Error: invalid file type. Please use a valid Excel file.");

            UploadResponse response = _upload.Upload(postedFiles, FileService.ImportFolder(_environment.WebRootPath));

            var id = await _providers.AzureCostImport.InsertAsync(new PSC.Domain.AzureCostImport()
            {
                FileName = Path.GetFileName(response.Files.FirstOrDefault()),
                UserId = User.Identity.Name
            });
            await _providers.AzureCostImportLog.InsertAsync(new PSC.Domain.AzureCostImportLog()
            {
                AzureCostImportId = id,
                LogType = PSC.Domain.Enums.LogType.UserInteraction,
                Username = User.Identity.Name,
                Message = $"User asked to import {filename}"
            });
            await _providers.AzureCostImportLog.InsertAsync(new PSC.Domain.AzureCostImportLog()
            {
                AzureCostImportId = id,
                LogType = PSC.Domain.Enums.LogType.Error,
                Message = $"{filename} has been uploaded " + (response.Success ? "without errors" : "with errors")
            });

            if (response.Success)
            {
                DataGrid g = _excel.ReadToGrid(response.Files.FirstOrDefault());
                if (g.Success)
                {
                    var (IsValid, errors) = _excel.ValidateHeader(g, FileStructure.AzureReportStructure);

                    await _providers.AzureCostImportLog.InsertAsync(new PSC.Domain.AzureCostImportLog()
                    {
                        AzureCostImportId = id,
                        LogType = IsValid ? PSC.Domain.Enums.LogType.Information : PSC.Domain.Enums.LogType.Error,
                        Message = $"{filename} has been validated: header is " + (IsValid ? "" : "not") + " valid"
                    });
                    if (!IsValid)
                        await _providers.AzureCostImportLog.InsertAsync(new PSC.Domain.AzureCostImportLog()
                        {
                            AzureCostImportId = id,
                            LogType = PSC.Domain.Enums.LogType.Error,
                            Message = $"{filename} can't be imported"
                        });

                    if (IsValid)
                        return Content("Success:" + string.Join(',', response.Files));
                    else
                        return Content("Error:Check the following errors: <ul>" +
                            string.Join(',', errors.Select(e => "<li>" + e + "</li>"))
                            + "</ul>");
                }
            }

            return Content("Error:The file is not valid.");
        }

        [Breadcrumb("Import")]
        [Breadcrumb("Azure Files")]
        public IActionResult List()
        {
            var model = new TableUI()
            {
                ApiUrl = "/api/AzureCostImport/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "FileName", Data = "FileName" },
                    new FieldUI() { Label = "Period", Data = "Period" },
                    new FieldUI() { Label = "UserId", Data = "UserId" }
                }, 
                ViewUrl = "/ExcelImport/ViewFile"
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Import Azure Files";
            return View("~/Views/Shared/TableView.cshtml", model);
        }

        [HttpGet]
        public IActionResult StartProcess(string filename)
        {
            var jobId = BackgroundJob.Enqueue(() => _process.Start(User.Identity.Name, filename));
            return Content("Ok");
        }

        [HttpGet]
        public async Task<IActionResult> ViewFile(long id)
        {
            FileViewModel model = new FileViewModel();

            var record = await _providers.AzureCostImport.GetAsync(id);
            if (record != null)
            {
                model.FileId = id;
                model.FileName = record.FileName;

                var logs = _providers.AzureCostImportLog.GetValues(id);
                var items = new System.Collections.Generic.List<Models.Components.Timeline.TimelineItem>();
                foreach(var ev in logs)
                {
                    items.Add(new Models.Components.Timeline.TimelineItem()
                    {
                        Body = ev.Message,
                        HeaderText = ev.Message,
                        ItemIcon = GetTimelineItemIcon(ev.LogType),
                        ItemType = GetTimelineEventType(ev.LogType),
                        Time = ev.LogData.ToShortTimeString()
                    });
                }

                model.Timeline = new Models.Components.Timeline.TimelineModel()
                {
                    Events = new List<Models.Components.Timeline.TimelineEvent>()
                    {
                        new Models.Components.Timeline.TimelineEvent()
                        {
                            EventDate = record.Period ?? DateTime.Now.ToString(),
                            EventType = Enums.Components.Timeline.TimelineEventType.Important,
                            Items = items
                        }
                    }
                };
            }

            return View(model);
        }

        public TimelineItemIcon GetTimelineItemIcon(LogType lType)
        {
            TimelineItemIcon rtn = TimelineItemIcon.Comment;
            switch (lType)
            {
                case LogType.Error:
                case LogType.Information:
                case LogType.Warning:
                    rtn = TimelineItemIcon.Comment;
                    break;
                case LogType.SendNotification:
                case LogType.ServiceMessage:
                    rtn = TimelineItemIcon.Wait;
                    break;
                case LogType.UserInteraction:
                    rtn = TimelineItemIcon.UserActivity;
                    break;
            }
            return rtn;
        }

        public TimelineEventType GetTimelineEventType(LogType lType)
        {
            TimelineEventType rtn = TimelineEventType.UndefinedStatus;
            switch (lType)
            {
                case LogType.Error:
                    rtn = TimelineEventType.Important;
                    break;
                case LogType.Information:
                    rtn = TimelineEventType.Information;
                    break;
                case LogType.Warning:
                    rtn = TimelineEventType.Warning;
                    break;
                case LogType.SendNotification:
                case LogType.ServiceMessage:
                    rtn = TimelineEventType.UndefinedStatus;
                    break;
                case LogType.UserInteraction:
                    rtn = TimelineEventType.Other;
                    break;
            }
            return rtn;
        }
    }
}
