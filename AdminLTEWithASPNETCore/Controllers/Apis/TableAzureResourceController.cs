﻿using AdminLTEWithASPNETCore.App.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Extensions;
using PSC.Persistence.Interfaces.CommonTables;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    /// <summary>
    /// Class TableAzureResourceController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TableAzureResourceController : CommonTableController<AzureResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableAzureResourceController"/> class.
        /// </summary>
        /// <param name="db">The providers.</param>
        /// <param name="log">The log.</param>
        public TableAzureResourceController(IAzureResourceRepository db, ILogger<TableAzureResourceController> log) : base(db, log)
        {
        }

        /// <summary>
        /// Creates new Azure category if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IActionResult.</returns>
        /// <response code="200">Azure Resource created</response>
        /// <response code="400">The name is missing or invalid values</response>
        /// <response code="500">Oops! Can't create your Azure Resource</response>
        [HttpPost]
        [Route("CreateIfNotExist")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AzureResource))]
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
        /// Posts the specified draw.
        /// </summary>
        /// <param name="draw">The draw.</param>
        /// <param name="length">The length.</param>
        /// <param name="start">The start.</param>
        /// <param name="columnSort">The column sort.</param>
        /// <param name="columnDirectrion">The column directrion.</param>
        /// <param name="search">The search.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [Route("Search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<AzureResource>))]
        public IActionResult Post([FromForm] string draw, [FromForm] string length, [FromForm] string start,
            string columnSort, string columnDirectrion, string search)
        {
            var searchValue = Request.Form.GetValueOrDefault("search[value]", search);

            Expression<Func<AzureResource, bool>> exp = r => r.Name.Contains(searchValue);

            var rtn = CommonTableService<AzureResource>.GetTableForUI(_db, Request.Form, draw, length, start,
                columnSort, columnDirectrion, search, exp);

            return StatusCode(StatusCodes.Status200OK, rtn);
        }
    }
}