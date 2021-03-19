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
    public class AzureResourceGroupController : Controller
    {
        [Breadcrumb("Tables")]
        [Breadcrumb("Azure Resource Group")]
        public IActionResult Index()
        {
            var model = new TableUI()
            {
                ApiUrl = "/api/v1/TableAzureResourceGroup/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Resource Group", Data = "Name" }
                }
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Azure Resource Group";
            return View("~/Views/Shared/TableView.cshtml", model);
        }
    }
}