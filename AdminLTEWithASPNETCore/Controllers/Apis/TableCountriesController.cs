using Microsoft.AspNetCore.Mvc;
using PSC.Domain.CommonTables;
using PSC.Extensions;
using PSC.Repositories;
using PSC.Services.TableAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
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
            var searchValue = Request.Form.GetValueOrDefault("search[value]", search);

            var customerData = (from tempcustomer in _db.Countries select tempcustomer);

            Expression<Func<Country, bool>> exp = r => r.Name.Contains(searchValue);
            var service = new TableService<Country>();
            var rtn = service.GetRecords(draw, length, start, columnSort, columnDirectrion,
                searchValue, Request.Form, customerData, exp);

            return Ok(rtn);
        }
    }
}