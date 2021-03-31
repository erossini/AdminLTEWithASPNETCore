using AdminLTEWithASPNETCore.Attributes;
using AdminLTEWithASPNETCore.Models.UI.CommonTables;
using Microsoft.AspNetCore.Mvc;
using PSC.Domain.CommonTables;
using PSC.Persistence.Interfaces.CommonTables;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Areas.Tables.Controllers
{
    [Area("Tables")]
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _db;

        public CountriesController(ICountryRepository db)
        {
            _db = db;
        }

        [Breadcrumb("Tables")]
        [Breadcrumb("Countries")]
        public IActionResult Index()
        {
            var model = new TableUI() {
                ApiUrl = "/api/v1/TableCountries/Search",
                Fields = new FieldUI[] {
                    new FieldUI() { Label = "ID", Data = "ID" },
                    new FieldUI() { Label = "Country", Data = "Name" },
                    new FieldUI() { Label = "Order", Data = "Order"}
                },
                CreateUrl = "/Tables/Countries/Create",
                EditUrl = "/Tables/Countries/Edit"
            };

            ViewData["Title"] = "Tables";
            ViewData["TableTitle"] = "Countries";
            return View("~/Views/Shared/TableView.cshtml", model);
        }

        [Breadcrumb("Tables")]
        [Breadcrumb("Countries", "Countries", "Index")]
        [Breadcrumb("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country model)
        {
            if (ModelState.IsValid)
            {
                await _db.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [Breadcrumb("Tables")]
        [Breadcrumb("Countries", "Countries", "Index")]
        [Breadcrumb("Edit")]
        public async Task<IActionResult> Edit(long id)
        {
            var record = await _db.GetByIdAsync(id);
            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Country model)
        {
            if (ModelState.IsValid)
            {
                await _db.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}