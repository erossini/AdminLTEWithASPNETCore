using Microsoft.AspNetCore.Http;
using PSC.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Extensions
{
    /// <summary>
    /// Class IFormFileExtensions.
    /// </summary>
    public static class IFormFileExtensions
    {
        /// <summary>
        /// save as an asynchronous operation.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="path">The path.</param>
        /// <returns>A Task&lt;System.String&gt; representing the asynchronous operation.</returns>
        /// <exception cref="System.Exception">Invalid file type. Please use a valid Excel file.</exception>
        public static async Task<string> SaveAsync(this IFormFile file, string path)
        {
            var extension = Path.GetExtension(file.FileName);
            if (extension.IndexOf("xls") == -1) throw new Exception("Invalid file type. Please use a valid Excel file.");

            try
            {
                var fileName = "Excel-" + Crypto.RandomString(10) + extension;
                var filePath = Path.Combine(path, fileName);

                // Save file to temporary Imports folder
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
