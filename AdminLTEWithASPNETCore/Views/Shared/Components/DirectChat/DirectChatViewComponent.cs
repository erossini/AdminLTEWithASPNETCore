using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.DirectChat
{
    public class DirectChatViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}