using AdminLTEWithASPNETCore.Models.Components.Charts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.LineChart
{
    /// <summary>
    /// Class AreaChartViewComponent.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    public class LineChartViewComponent : ViewComponent
    {
        /// <summary>
        /// invoke the creation of a new LineChart
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task&lt;IViewComponentResult&gt; representing the asynchronous operation.</returns>
        public async Task<IViewComponentResult> InvokeAsync(ChartModel model)
        {
            return View("Default", model);
        }
    }
}
