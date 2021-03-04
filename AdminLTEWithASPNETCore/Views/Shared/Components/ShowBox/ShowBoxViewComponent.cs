using AdminLTEWithASPNETCore.Enums.Components;
using AdminLTEWithASPNETCore.Models.Components.Boxes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.ShowBox
{
    /// <summary>
    /// Class ShowBoxViewComponent.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    public class ShowBoxViewComponent : ViewComponent
    {
        /// <summary>
        /// Invoke the creation of ShowBoxView
        /// </summary>
        /// <param name="title">The title of the box</param>
        /// <param name="description">The description under the title</param>
        /// <param name="src">The URL to redirect the user</param>
        /// <param name="alt">The alternate text for the URL</param>
        /// <param name="cssBackground">The CSS background.</param>
        /// <param name="fontawesomeIcon">The fontawesome icon to display</param>
        /// <param name="shadow">The shadow type for the box</param>
        /// <returns>A Task&lt;IViewComponentResult&gt; representing the asynchronous operation.</returns>
        public async Task<IViewComponentResult> InvokeAsync(string title, string description,
            string src, string alt, string cssBackground, string fontawesomeIcon,
            ShadowType shadow)
        {
            ShowBoxModel model = new ShowBoxModel();
            model.BackgroundColor = cssBackground ?? null;
            model.Icon = fontawesomeIcon ?? null;
            model.Shadow = shadow;
            model.SubText = description ?? string.Empty;
            model.Text = title;
            model.Link = src ?? "#";
            model.LinkDescription = alt;

            return View("Default", model);
        }
    }
}
