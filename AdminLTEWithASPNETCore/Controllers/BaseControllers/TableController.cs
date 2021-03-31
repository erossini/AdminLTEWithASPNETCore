using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.Persistence.Interfaces;
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
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TableController<T> : ControllerBase where T : class
    {
        /// <summary>
        /// The log
        /// </summary>
        protected ILogger<TableController<T>> _log;

        /// <summary>
        /// The providers
        /// </summary>
        protected IAsyncRepository<T> _db;

        public TableController(IAsyncRepository<T> repository, ILogger<TableController<T>> log)
        {
            _log = log;
            _db = repository;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        [Route("GetValue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetValue(long id)
        {
            var rtn = await _db.GetByIdAsync(id);
            return rtn != null ? Ok(rtn) : NotFound();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <returns>The list of Azure Categories</returns>
        /// <response code="200">Retrieved the list of Azure Category</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetValues()
        {
            return Ok(_db.ListAllAsync());
        }

        /// <summary>
        /// Patches the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>IActionResult.</returns>
        [HttpPatch]
        public async Task<IActionResult> Patch(T value)
        {
            if (value == null)
                return BadRequest();

            await _db.UpdateAsync(value);
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
        public async Task<IActionResult> Post(T value)
        {
            if (value == null)
                return BadRequest();

            return Ok(await _db.AddAsync(value));
        }

        #region Delete
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(long id)
        {
            await _db.DeleteAsync(id);
            return Ok();
        }

        /// <summary>
        /// Deletes the list.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>IActionResult.</returns>
        [HttpDelete]
        [Route("DeleteList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteList(long[] ids)
        {
            await _db.DeleteMultipleAsync(ids);
            return Ok();
        }
        #endregion
    }
}
