using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.Domain.CommonTables;
using PSC.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TableAzureCategoryController : ControllerBase
    {
        /// <summary>
        /// The log
        /// </summary>
        private ILogger<TableAzureCategoryController> _log;

        /// <summary>
        /// The providers
        /// </summary>
        private DataProviders _providers;
        /// <summary>
        /// Initializes a new instance of the <see cref="TableAzureCategoryController"/> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        /// <param name="log">The log.</param>
        public TableAzureCategoryController(DataProviders providers, ILogger<TableAzureCategoryController> log)
        {
            _log = log;
            _providers = providers;
        }

        /// <summary>
        /// Creates new Azure category if not exist.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IActionResult.</returns>
        /// <response code="200">Azure Category created</response>
        /// <response code="400">The name is missing or invalid values</response>
        /// <response code="500">Oops! Can't create your Azure Category</response>
        [HttpPost]
        [Route("CreateIfNotExist")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AzureCategory))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateIfNotExist(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            return Ok(await _providers.AzureCategory.CreateIfNotExist(name));
        }

        /// <summary>
        /// Gets the name of the identifier by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetIdByName")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public IActionResult GetIdByName(string name)
        {
            return Ok(_providers.AzureCategory.GetIdByNameAsync(name));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetValue")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AzureCategory))]
        public async Task<IActionResult> GetValue(long id)
        {
            return Ok(await _providers.AzureCategory.GetAsync(id));
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>The list of Azure Categories</returns>
        /// <response code="200">Retrieved the list of Azure Category</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AzureCategory>))]
        public IActionResult GetValues()
        {
            return Ok(_providers.AzureCategory.GetValues());
        }
        /// <summary>
        /// Patches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IActionResult.</returns>
        [HttpPatch]
        public async Task<IActionResult> Patch(AzureCategory value)
        {
            if (value == null)
                return BadRequest();

            await _providers.AzureCategory.ReplaceAsync(value.ID, value);
            return Ok();
        }

        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(AzureCategory value)
        {
            if (value == null)
                return BadRequest();

            return Ok(await _providers.AzureCategory.InsertAsync(value));
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
            return Ok(await _providers.AzureCategory.DeleteAsync(id));
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
            return Ok(await _providers.AzureCategory.DeleteMultipleAsync(ids));
        }
        #endregion
    }
}
