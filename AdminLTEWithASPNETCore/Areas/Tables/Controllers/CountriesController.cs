using AdminLTEWithASPNETCore.Models.UI.CommonTables;
using Microsoft.AspNetCore.Mvc;
using PSC.Domain.CommonTables;
using PSC.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Areas.Tables.Controllers
{
    [Area("Tables")]
    public class CountriesController : Controller
    {
        private readonly DataProviders _providers;

        public CountriesController(DataProviders dataProviders)
        {
            this._providers = dataProviders;
        }

        public IActionResult Index()
        {
            var model = new TableUI() {
                ApiUrl = "/api/TableCountries/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Country", Data = "Name" }
                },
                EditUrl = "/Tables/Countries/Edit"
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Countries";
            return View("~/Areas/Tables/Views/Shared/Index.cshtml", model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Order")]Country model)
        {
            if (ModelState.IsValid)
            {
                await _providers.Countries.InsertAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var record = await _providers.Countries.GetAsync(id);
            return View(record);
        }
    }
}
