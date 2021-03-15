using AdminLTEWithASPNETCore.Attributes;
using AdminLTEWithASPNETCore.Controllers.Apis;
using AdminLTEWithASPNETCore.Models.UI.CommonTables;
using Microsoft.AspNetCore.Mvc;
using Ploeh.Hyprlinkr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Areas.Tables.Controllers
{
    [Area("Tables")]
    public class AzureLocationController : Controller
    {
        [Breadcrumb("Tables")]
        [Breadcrumb("Azure Location")]
        public IActionResult Index()
        {
            var model = new TableUI()
            {
                ApiUrl = "/api/TableAzureLocation/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Location", Data = "Name" }
                }
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Azure Location";
            return View("~/Views/Shared/TableView.cshtml", model);
        }
    }
}