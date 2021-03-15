using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Extensions;
using PSC.Providers;
using PSC.Services.AspNetCore.TableAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    /// <summary>
    /// Class TableAzureResourceGroupController.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class TableAzureResourceGroupController : ControllerBase
    {
        /// <summary>
        /// The log
        /// </summary>
        private ILogger<TableAzureResourceGroupController> _log;

        /// <summary>
        /// The providers
        /// </summary>
        private DataProviders _providers;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableAzureResourceGroupController"/> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        /// <param name="log">The log.</param>
        public TableAzureResourceGroupController(DataProviders providers, ILogger<TableAzureResourceGroupController> log)
        {
            _log = log;
            _providers = providers;
        }

        /// <summary>
        /// Creates new Azure category if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IActionResult.</returns>
        /// <response code="200">Azure Resource Group created</response>
        /// <response code="400">The name is missing or invalid values</response>
        /// <response code="500">Oops! Can't create your Azure Resource Group</response>
        [HttpPost]
        [Route("CreateIfNotExist")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AzureResourceGroup))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateIfNotExist(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            return Ok(await _providers.AzureResourceGroup.CreateIfNotExist(name));
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

            var rtn = _providers.AzureResourceGroup.GetIdByNameAsync(name);
            return rtn != 0 ? Ok(rtn) : NotFound();
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetValue")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AzureResourceGroup))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetValue(long id)
        {
            var rtn = await _providers.AzureResourceGroup.GetAsync(id);
            return rtn != null ? Ok(rtn) : NotFound();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>The list of Azure Resource Group</returns>
        /// <response code="200">Retrieved the list of Azure Resource Group</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AzureResourceGroup>))]
        public IActionResult GetValues()
        {
            return Ok(_providers.AzureResourceGroup.GetValues());
        }

        /// <summary>
        /// Patches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IActionResult.</returns>
        [HttpPatch]
        public async Task<IActionResult> Patch(AzureResourceGroup value)
        {
            if (value == null)
                return BadRequest();

            await _providers.AzureResourceGroup.ReplaceAsync(value.ID, value);
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
        public async Task<IActionResult> Post(AzureResourceGroup value)
        {
            if (value == null)
                return BadRequest();

            return Ok(await _providers.AzureResourceGroup.InsertAsync(value));
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<AzureResourceGroup>))]
        public IActionResult Post([FromForm] string draw, [FromForm] string length, [FromForm] string start,
            string columnSort, string columnDirectrion, string search)
        {
            var searchValue = Request.Form.GetValueOrDefault("search[value]", search);

            var customerData = _providers.AzureResourceGroup.GetValues();

            Expression<Func<AzureResourceGroup, bool>> exp = r => r.Name.Contains(searchValue);
            var service = new TableService<AzureResourceGroup>();
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
            return Ok(await _providers.AzureResourceGroup.DeleteAsync(id));
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
            return Ok(await _providers.AzureResourceGroup.DeleteMultipleAsync(ids));
        }
        #endregion
    }
}
