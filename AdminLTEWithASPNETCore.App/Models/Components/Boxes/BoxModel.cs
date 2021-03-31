using AdminLTEWithASPNETCore.Enums.Components;
using AdminLTEWithASPNETCore.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Boxes
{
    /// <summary>
    /// Class BoxModel.
    /// </summary>
    public class BoxModel
    {
        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public string BackgroundColor { get; set; } = "bg-blue";
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public string Icon { get; set; } = "fa-info";
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets the shadow.
        /// </summary>
        /// <value>The shadow.</value>
        public ShadowType Shadow { get; set; } = ShadowType.None;
        /// <summary>
        /// Gets or sets the sub text.
        /// </summary>
        /// <value>The sub text.</value>
        public string SubText { get; set; }

        /// <summary>
        /// Gets the CSS for the shadow
        /// </summary>
        /// <returns>Returns the CSS for the requested shadow</returns>
        public string ShadowText => Shadow.GetDescription();
    }
}
