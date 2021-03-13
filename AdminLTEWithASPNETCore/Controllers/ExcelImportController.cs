using AdminLTEWithASPNETCore.Code.Processes;
using AdminLTEWithASPNETCore.Models.Controllers;
using AdminLTEWithASPNETCore.Models.Imports;
using AdminLTEWithASPNETCore.Services;
using Hangfire;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IWebHostEnvironment _environment;
        private readonly ImportExcel _excel;
        private readonly ImportAzureProcess _process;
        private readonly UploadFiles _upload;

        public ExcelImportController(IWebHostEnvironment environment, ImportExcel excel,
            ImportAzureProcess process, UploadFiles upload)
        {
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
        public IActionResult UploadExcel(List<IFormFile> postedFiles)
        {
            var extension = Path.GetExtension(postedFiles.FirstOrDefault().FileName);
            if (extension.IndexOf("xls") == -1) return Content ("Error: invalid file type. Please use a valid Excel file.");

            UploadResponse response = _upload.Upload(postedFiles, FileService.ImportFolder(_environment.WebRootPath));
            if (response.Success)
            {
                DataGrid g = _excel.ReadToGrid(response.Files.FirstOrDefault());
                if (g.Success)
                {
                    var (IsValid, errors) = _excel.ValidateHeader(g, FileStructure.AzureReportStructure);
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

        [HttpGet]
        public IActionResult StartProcess(string filename)
        {
            var jobId = BackgroundJob.Enqueue(() => _process.Start(User.Identity.Name, filename));
            return Content("Ok");
        }
    }
}
