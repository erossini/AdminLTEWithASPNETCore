using AdminLTEWithASPNETCore.Models.Components.Cards;
using AdminLTEWithASPNETCore.Models.Components.Timeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Controllers
{
    /// <summary>
    /// Class FileViewModel.
    /// </summary>
    public class FileViewModel
    {
        /// <summary>
        /// Gets or sets the file identifier.
        /// </summary>
        /// <value>The file identifier.</value>
        public long FileId { get; set; }
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the timeline.
        /// </summary>
        /// <value>The timeline.</value>
        public TimelineModel Timeline { get; set; }
        /// <summary>
        /// Gets or sets the card.
        /// </summary>
        /// <value>The card.</value>
        public CardModel Card { get; set; }
    }
}