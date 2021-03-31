using AdminLTEWithASPNETCore.Models.Controllers.Api;
using AdminLTEWithASPNETCore.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSC.Persistence.Interfaces.Tables;
using PSC.Services.Imports;
using PSC.Services.Imports.Models;
using System.IO;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly IAzureCostImportRepository _providers;
        private readonly ImportExcel _excel;
        private readonly IWebHostEnvironment _environment;

        public FilesController(IAzureCostImportRepository providers, IWebHostEnvironment environment, ImportExcel excel)
        {
            _providers = providers;
            _environment = environment;
            _excel = excel;
        }

        /// <summary>
        /// Gets the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>DataGrid.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(DataGrid))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string filename)
        {
            filename = Path.Combine(FileService.ImportFolder(_environment.WebRootPath), filename);

            var rtn = _excel.ReadToGrid(filename);
            return rtn != null ? StatusCode(StatusCodes.Status200OK, rtn) : StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        [Route("SetMetadata")]
        public async Task<IActionResult> SetMetadata(FileMetadata metadata)
        {
            var id = _providers.GetIdByNameAsync(Path.GetFileName(metadata.Filename));
            if (id > 0)
            {
                var record = await _providers.GetByIdAsync(id);
                record.Period = metadata.Text;
                await _providers.UpdateAsync(record);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
