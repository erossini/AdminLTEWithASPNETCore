using AdminLTEWithASPNETCore.App.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Extensions;
using PSC.Persistence.Interfaces.CommonTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TableCountriesController : CommonTableController<Country>
    {
        public TableCountriesController(ICountryRepository db, ILogger<TableCountriesController> log) : base(db, log)
        {
        }

        /// <summary>
        /// Creates new Azure category if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IActionResult.</returns>
        /// <response code="200">Azure Subcategory created</response>
        /// <response code="400">The name is missing or invalid values</response>
        /// <response code="500">Oops! Can't create your Azure Subcategory</response>
        [HttpPost]
        [Route("CreateIfNotExist")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Country))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateIfNotExist(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            return Ok(await _db.CreateIfNotExist(name));
        }

        /// <summary>
        /// Gets the name of the identifier by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetIdByName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetIdByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            var rtn = _db.GetIdByNameAsync(name);
            return rtn != 0 ? Ok(rtn) : NotFound();
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

            Expression<Func<Country, bool>> exp = r => r.Name.Contains(search);

            var rtn = CommonTableService<Country>.GetTableForUI(_db, Request.Form, draw, length, start,
                columnSort, columnDirectrion, search, exp);

            return StatusCode(StatusCodes.Status200OK, rtn);
        }
    }
}