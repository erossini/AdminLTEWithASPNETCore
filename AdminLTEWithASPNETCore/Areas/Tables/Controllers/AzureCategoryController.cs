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
    public class AzureCategoryController : Controller
    {
        [Breadcrumb("Tables")]
        [Breadcrumb("Azure Category")]
        public IActionResult Index()
        {
            var model = new TableUI()
            {
                ApiUrl = "/api/v1/TableAzureCategory/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Category", Data = "Name" }
                }
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Azure Category";
            return View("~/Views/Shared/TableView.cshtml", model);
        }
    }
}