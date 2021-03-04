using AdminLTEWithASPNETCore.Enums.Components;
using AdminLTEWithASPNETCore.Models.Components.Boxes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.InfoBox
{
    /// <summary>
    /// Class InfoBoxViewComponent.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    public class InfoBoxViewComponent : ViewComponent
    {
        /// <summary>
        /// invoke as an asynchronous operation.
        /// </summary>
        /// <param name="title">The title of the box</param>
        /// <param name="description">The description under the title</param>
        /// <param name="cssBackground">The CSS background.</param>
        /// <param name="fontawesomeIcon">The fontawesome icon.</param>
        /// <param name="shadow">The shadow type for the box</param>
        /// <returns>A Task&lt;IViewComponentResult&gt; representing the asynchronous operation.</returns>
        public async Task<IViewComponentResult> InvokeAsync(string title, string description, 
            string cssBackground, string fontawesomeIcon, ShadowType shadow = ShadowType.None)
        {
            BoxModel model = new BoxModel();
            model.BackgroundColor = cssBackground ?? null;
            model.Icon = fontawesomeIcon ?? null;
            model.SubText = description ?? string.Empty;
            model.Text = title;
            model.Shadow = shadow;

            return View("Default", model);
        }
    }
}
