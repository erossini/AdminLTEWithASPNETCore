using AdminLTEWithASPNETCore.Models.Components.Cards;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Views.Shared.Components.Card
{
    public class CardViewComponent : ViewComponent
    {
        /// <summary>
        /// invoke the creationg of a card
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A Task&lt;IViewComponentResult&gt; representing the asynchronous operation.</returns>
        public async Task<IViewComponentResult> InvokeAsync(CardModel model)
        {
            return View("Default", model);
        }
    }
}
