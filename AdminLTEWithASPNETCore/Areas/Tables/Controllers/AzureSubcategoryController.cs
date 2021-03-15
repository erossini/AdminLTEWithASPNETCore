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
    public class AzureSubcategoryController : Controller
    {
        [Breadcrumb("Tables")]
        [Breadcrumb("Azure Countries")]
        public IActionResult Index()
        {
            var model = new TableUI()
            {
                ApiUrl = "/api/TableAzureSubcategory/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Subcategory", Data = "Name" }
                }
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Azure Subcategory";
            return View("~/Views/Shared/TableView.cshtml", model);
        }
    }
}