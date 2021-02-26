using AdminLTEWithASPNETCore.Enums.Components;
using AdminLTEWithASPNETCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Charts
{
    /// <summary>
    /// Class ChartModel.
    /// </summary>
    public class ChartModel
    {
        /// <summary>
        /// Gets or sets the name of the chart.
        /// </summary>
        /// <value>The name of the chart.</value>
        public string ChartId { get; set; }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; set; } = 200;
        /// <summary>
        /// Gets or sets the labels.
        /// </summary>
        /// <value>The labels.</value>
        public List<string> Labels { get; set; } = new List<string>();
        /// <summary>
        /// Gets or sets the datasets.
        /// </summary>
        /// <value>The datasets.</value>
        public List<Dataset> Datasets { get; set; } = new List<Dataset>();
        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        /// <value>The color of the font.</value>
        public string FontColor { get; set; } = "#495057";
        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        /// <value>The font style.</value>
        public string FontStyle { get; set; } = "bold";
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; } = "line";
        /// <summary>
        /// Gets or sets a value indicating whether [show legend].
        /// </summary>
        /// <value><c>true</c> if [show legend]; otherwise, <c>false</c>.</value>
        public bool ShowLegend { get; set; } = false;
        /// <summary>
        /// Gets or sets the legend position.
        /// </summary>
        /// <value>The legend position.</value>
        public PositionType PositionLegend { get; set; } = PositionType.Top;
        /// <summary>
        /// Gets the position legend.
        /// </summary>
        /// <value>The position legend.</value>
        public string LegendPosition => PositionLegend.GetDescription();
        /// <summary>
        /// Gets or sets the x axes.
        /// </summary>
        /// <value>The x axes.</value>
        public Axes XAxes { get; set; } = new Axes();
        /// <summary>
        /// Gets or sets the y axes.
        /// </summary>
        /// <value>The y axes.</value>
        public Axes YAxes { get; set; } = new Axes();
    }
}