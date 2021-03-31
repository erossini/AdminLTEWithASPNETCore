using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Services
{
    /// <summary>
    /// Class FileService.
    /// </summary>
    public static class FileService
    {
        /// <summary>
        /// Imports the folder.
        /// </summary>
        /// <param name="rootPath">The web root path.</param>
        /// <returns>System.String.</returns>
        public static string ImportFolder(string rootPath)
        {
            string path = Path.Combine(rootPath, "Uploads", "Imports");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}
