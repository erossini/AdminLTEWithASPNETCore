using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Services.AspNetCore.Models.Responses
{
    /// <summary>
    /// Class Upload response.
    /// </summary>
    public class UploadResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UploadResponse"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>The files.</value>
        public List<string> Files { get; set; } = new List<string>();
    }
}
