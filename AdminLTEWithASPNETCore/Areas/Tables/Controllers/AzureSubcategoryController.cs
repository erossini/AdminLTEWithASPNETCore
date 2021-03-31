using AdminLTEWithASPNETCore.Attributes;
using AdminLTEWithASPNETCore.Models.UI.CommonTables;
using Microsoft.AspNetCore.Mvc;

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
                ApiUrl = "/api/v1/TableAzureSubcategory/Search",
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