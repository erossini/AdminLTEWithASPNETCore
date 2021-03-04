using AdminLTEWithASPNETCore.Enums.Components;
using AdminLTEWithASPNETCore.Models.Components.Boxes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.ProgressBox
{
    /// <summary>
    /// Class ProgressBoxViewComponent.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    public class ProgressBoxViewComponent : ViewComponent
    {
        /// <summary>
        /// Invoke the creation of ProgressBoxView
        /// </summary>
        /// <param name="title">The title of the box</param>
        /// <param name="description">The description under the title</param>
        /// <param name="percent">The percent of the progress bar</param>
        /// <param name="percentDescription">The percent description.</param>
        /// <param name="cssBackground">The CSS background.</param>
        /// <param name="fontawesomeIcon">The fontawesome icon.</param>
        /// <param name="shadow">The shadow type for the box</param>
        /// <returns>A Task&lt;IViewComponentResult&gt; representing the asynchronous operation.</returns>
        public async Task<IViewComponentResult> InvokeAsync(string title, string description, 
            int percent, string percentDescription,
            string cssBackground, string fontawesomeIcon,
            ShadowType shadow)
        {
            ProgressBoxModel model = new ProgressBoxModel();
            model.BackgroundColor = cssBackground ?? null;
            model.Icon = fontawesomeIcon ?? null;
            model.Shadow = shadow;
            model.SubText = description ?? string.Empty;
            model.Text = title;
            model.Percent = percent;
            model.PercentDescription = percentDescription;

            return View("Default", model);
        }
    }
}
