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
    public class AzureResourceController : Controller
    {
        [Breadcrumb("Tables")]
        [Breadcrumb("Azure Resource")]
        public IActionResult Index()
        {
            var model = new TableUI()
            {
                ApiUrl = "/api/TableAzureResource/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Resource", Data = "Name" }
                }
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Azure Resource";
            return View("~/Views/Shared/TableView.cshtml", model);
        }
    }
}