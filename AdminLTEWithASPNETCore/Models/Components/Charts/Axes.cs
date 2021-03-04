using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Charts
{
    /// <summary>
    /// Class Axes.
    /// </summary>
    public class Axes
    {
        /// <summary>
        /// Gets or sets if the axis must be shown
        /// </summary>
        /// <value><c>true</c> if the axis must be shown otherwise, <c>false</c>.</value>
        public bool ShowAxes { get; set; } = false;
        /// <summary>
        /// Gets or sets if the grid lines must to be shown
        /// </summary>
        /// <value><c>true</c> if the grid lines must be shown otherwise, <c>false</c>.</value>
        public bool ShowGridLines { get; set; } = false;
    }
}
