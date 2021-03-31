using System.Collections.Generic;

namespace PSC.Services.Imports.Models
{
    /// <summary>
    /// Class DataGrid.
    /// </summary>
    public class DataGrid
    {
        public bool Success { get; set; } = false;

        /// <summary>
        /// Gets the headers.
        /// </summary>
        /// <value>The headers.</value>
        public List<string> Headers { get; } = new List<string>();

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <value>The types.</value>
        public Dictionary<string, string> Types { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>The rows.</value>
        public List<Dictionary<string, string>> Rows { get; } = new List<Dictionary<string, string>>();
    }
}