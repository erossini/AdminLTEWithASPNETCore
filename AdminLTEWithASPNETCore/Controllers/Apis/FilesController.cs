using AdminLTEWithASPNETCore.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSC.Services.Imports;
using PSC.Services.Imports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ImportExcel _excel;
        private readonly IWebHostEnvironment _environment;

        public FilesController(IWebHostEnvironment environment, ImportExcel excel)
        {
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
        public IActionResult Get(string filename)
        {
            filename = Path.Combine(FileService.ImportFolder(_environment.WebRootPath), filename);
            return StatusCode(StatusCodes.Status200OK, _excel.ReadToGrid(filename));
        }
    }
}
