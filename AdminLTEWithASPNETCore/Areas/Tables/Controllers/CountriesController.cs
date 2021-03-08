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
                ApiUrl = "https://localhost:5001/api/TableCountries",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "idCountry" },
                    new FieldUI() { Label = "Country", Data = "name" }
                }
            };

            ViewData["Title"] = "Countries";
            return View("~/Areas/Tables/Views/Shared/Index.cshtml", model);
        }
    }
}
