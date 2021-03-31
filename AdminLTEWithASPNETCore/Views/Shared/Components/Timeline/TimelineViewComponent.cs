using AdminLTEWithASPNETCore.Models.Components.Timeline;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.Timeline
{
    /// <summary>
    /// Class TimelineViewComponent.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ViewComponent" />
    public class TimelineViewComponent : ViewComponent
    {
        /// <summary>
        /// invoke as an asynchronous operation.
        /// </summary>
        /// <returns>A Task&lt;IViewComponentResult&gt; representing the asynchronous operation.</returns>
        public async Task<IViewComponentResult> InvokeAsync(TimelineModel model)
        {
            return View("Default", model);
        }
    }
}