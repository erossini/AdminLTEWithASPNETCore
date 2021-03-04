using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Charts
{
    /// <summary>
    /// Class Dataset.
    /// </summary>
    public class Dataset
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public List<decimal> Data { get; set; }
        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public List<string> BackgroundColors { get; set; } = new List<string>() { "transparent" };
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public string BorderColor { get; set; } = "#007bff";
        /// <summary>
        /// Gets or sets the label for this data
        /// </summary>
        /// <value>The label.</value>
        public string Label { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the color of the point border.
        /// </summary>
        /// <value>The color of the point border.</value>
        public string PointBorderColor { get; set; } = "#007bff";
        /// <summary>
        /// Gets or sets the color of the point background.
        /// </summary>
        /// <value>The color of the point background.</value>
        public string PointBackgroundColor { get; set; } = "#007bff";
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Dataset"/> is fill.
        /// </summary>
        /// <value><c>true</c> if fill; otherwise, <c>false</c>.</value>
        public bool Fill { get; set; } = false;
        /// <summary>
        /// Gets or sets the color of the point hover background.
        /// </summary>
        /// <value>The color of the point hover background.</value>
        public string PointHoverBackgroundColor { get; set; } = "#007bff";
        /// <summary>
        /// Gets or sets the color of the point hover border.
        /// </summary>
        /// <value>The color of the point hover border.</value>
        public string PointHoverBorderColor { get; set; } = "#007bff";
    }
}
