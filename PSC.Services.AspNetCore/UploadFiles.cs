using Microsoft.AspNetCore.Http;
using PSC.Services.AspNetCore.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Services.AspNetCore
{
    /// <summary>
    /// Class UploadFiles.
    /// </summary>
    public class UploadFiles
    {
        /// <summary>
        /// Uploads the specified posted files.
        /// </summary>
        /// <param name="postedFiles">The posted files.</param>
        /// <returns>UploadResponse.</returns>
        public UploadResponse Upload(List<IFormFile> postedFiles, string uploadPathFolder)
        {
            UploadResponse rtn = new UploadResponse();
            rtn.Success = true;

            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(postedFile.FileName) + 
                                  "-" + Crypto.RandomString(10) +
                                  Path.GetExtension(postedFile.FileName);
                string fullPath = Path.Combine(uploadPathFolder, fileName);
                rtn.Files.Add(fullPath);

                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }

            return rtn;
        }
    }
}
