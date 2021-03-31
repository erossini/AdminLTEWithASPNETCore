using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.UI.CommonTables
{
    /// <summary>
    /// Class FieldUI.
    /// </summary>
    public class FieldUI
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the render.
        /// </summary>
        /// <value>The render.</value>
        [JsonProperty("render")]
        public string Render { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FieldUI"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        [JsonProperty("visible")]
        public bool Visible { get; set; } = true;
    }
}
