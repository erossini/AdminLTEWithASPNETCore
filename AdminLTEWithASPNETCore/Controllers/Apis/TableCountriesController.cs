using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSC.Domain.CommonTables;
using PSC.Extensions;
using PSC.Providers;
using PSC.Repositories;
using PSC.Services.AspNetCore.TableAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class TableCountriesController : ControllerBase
    {
        private DataProviders _providers;

        public TableCountriesController(DataProviders provider)
        {
            _providers = provider;
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
        [Route("Search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<Country>))]
        public IActionResult Post([FromForm] string draw, [FromForm] string length, [FromForm] string start, 
            string columnSort, string columnDirectrion, string search)
        {
            var searchValue = Request.Form.GetValueOrDefault("search[value]", search);

            var customerData = _providers.Countries.GetValues();

            Expression<Func<Country, bool>> exp = r => r.Name.Contains(searchValue);
            var service = new TableService<Country>();
            var rtn = service.GetRecords(draw, length, start, columnSort, columnDirectrion,
                searchValue, Request.Form, customerData, exp);

            return StatusCode(StatusCodes.Status200OK, rtn);
        }
    }
}