using AdminLTEWithASPNETCore.Models.UI.CommonTables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Areas.Tables.Controllers
{
    [Area("Tables")]
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            var model = new TableUI() {
                ApiUrl = "/api/TableCountries",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Country", Data = "Name" }
                }
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Countries";
            return View("~/Areas/Tables/Views/Shared/Index.cshtml", model);
        }
    }
}
