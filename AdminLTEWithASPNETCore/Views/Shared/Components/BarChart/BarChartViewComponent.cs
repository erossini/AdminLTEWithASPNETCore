using AdminLTEWithASPNETCore.Models.Components.Charts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.BarChart
{
    public class BarChartViewComponent : ViewComponent
    {
        /// <summary>
        /// invoke the creation of a new BarChart
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task&lt;IViewComponentResult&gt; representing the asynchronous operation.</returns>
        public async Task<IViewComponentResult> InvokeAsync(ChartModel model)
        {
            return View("Default", model);
        }
    }
}