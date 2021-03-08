using Microsoft.AspNetCore.Mvc;
using PSC.Domain.CommonTables;
using PSC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableCountriesController : ControllerBase
    {
        private readonly PSCContext _db;

        public TableCountriesController(PSCContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Returns the list of countries
        /// </summary>
        /// <param name="draw">The draw.</param>
        /// <param name="length">The length of the page in record</param>
        /// <param name="start">The start page</param>
        /// <param name="columnSort">The column for sorting the list</param>
        /// <param name="columnDirectrion">The column direction (asc, desc) for sorting the list.</param>
        /// <param name="search">The search</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        [HttpPost]
        public IActionResult Post([FromForm] string draw, [FromForm] string length, [FromForm] string start, 
            string columnSort, string columnDirectrion, string search)
        {
            var sortColumn = columnSort ?? Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = columnDirectrion ?? Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = search ?? Request.Form["search[value]"].FirstOrDefault();

            int pageSize = !string.IsNullOrEmpty(length) ? Convert.ToInt32(length) : 10;
            int skip = !string.IsNullOrEmpty(start) ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var customerData = (from tempcustomer in _db.Countries select tempcustomer);
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);

            if (!string.IsNullOrEmpty(searchValue))
                customerData = customerData.Where(m => m.Name.Contains(searchValue));

            recordsTotal = customerData.Count();
            
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }
    }
}