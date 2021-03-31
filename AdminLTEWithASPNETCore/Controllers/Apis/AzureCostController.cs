using AdminLTEWithASPNETCore.App.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Extensions;
using PSC.Persistence.Interfaces.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    /// <summary>
    /// Class TableAzureCategoryController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AzureCostController : TableController<AzureCost>
    {
        public AzureCostController(IAzureCostRepository db, ILogger<AzureCostController> log) : base(db, log)
        {
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<AzureCost>))]
        public IActionResult Post([FromForm] string draw, [FromForm] string length, [FromForm] string start,
            string columnSort, string columnDirectrion, string search)
        {
            var searchValue = Request.Form.GetValueOrDefault("search[value]", search);

            Expression<Func<AzureCost, bool>> exp =
                r => r.AzureCategory.Name.Contains(searchValue) || r.AzureLocation.Name.Contains(searchValue) ||
                     r.AzureResource.Name.Contains(searchValue) || r.AzureResourceGroup.Name.Contains(searchValue) ||
                     r.AzureSubcategory.Name.Contains(searchValue);

            var rtn = CommonTableService<AzureCost>.GetTableForUI(_db, Request.Form, draw, length, start,
                columnSort, columnDirectrion, search, exp);

            return StatusCode(StatusCodes.Status200OK, rtn);
        }
    }
}
