using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.Domain;
using PSC.Domain.CommonTables;
using PSC.Extensions;
using PSC.Providers;
using PSC.Repositories;
using PSC.Services.AspNetCore.Models.Responses;
using PSC.Services.AspNetCore.TableAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    /// <summary>
    /// Class TableAzureCategoryController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AzureCostController : ControllerBase
    {
        /// <summary>
        /// The log
        /// </summary>
        private ILogger<AzureCostController> _log;

        /// <summary>
        /// The providers
        /// </summary>
        private DataProviders _providers;
        private PSCContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureCostController"/> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        /// <param name="log">The log.</param>
        public AzureCostController(DataProviders providers, PSCContext db, ILogger<AzureCostController> log)
        {
            _db = db;
            _log = log;
            _providers = providers;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetValue")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AzureCost))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetValue(long id)
        {
            var rtn = await _providers.AzureCost.GetAsync(id);
            return rtn != null ? Ok(rtn) : NotFound();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>The list of Azure Cost</returns>
        /// <response code="200">Retrieved the list of Azure Cost</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AzureCost>))]
        public IActionResult GetValues()
        {
            return Ok(_providers.AzureCost.GetValues());
        }

        /// <summary>
        /// Patches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IActionResult.</returns>
        [HttpPatch]
        public async Task<IActionResult> Patch(AzureCost value)
        {
            if (value == null)
                return BadRequest();

            await _providers.AzureCost.ReplaceAsync(value.ID, value);
            return Ok();
        }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(long))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AzureCost value)
        {
            if (value == null)
                return BadRequest();

            return Ok(await _providers.AzureCost.InsertAsync(value));
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

            var customerData = _providers.AzureCost.GetValues();

            Expression < Func<AzureCost, bool> > exp =
                r => r.AzureCategory.Name.Contains(searchValue) || r.AzureLocation.Name.Contains(searchValue) ||
                     r.AzureResource.Name.Contains(searchValue) || r.AzureResourceGroup.Name.Contains(searchValue) ||
                     r.AzureSubcategory.Name.Contains(searchValue);

            var service = new TableService<AzureCost>();
            var rtn = service.GetRecords(draw, length, start, columnSort, columnDirectrion,
                searchValue, Request.Form, customerData, exp);

            return StatusCode(StatusCodes.Status200OK, rtn);
        }

        #region Delete
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await _providers.AzureCost.DeleteAsync(id));
        }

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [Route("DeleteList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteList(long[] ids)
        {
            return Ok(await _providers.AzureCost.DeleteMultipleAsync(ids));
        }
        #endregion
    }
}
