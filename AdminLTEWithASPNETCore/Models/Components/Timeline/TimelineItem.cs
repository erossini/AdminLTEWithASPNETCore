using AdminLTEWithASPNETCore.Enums.Components.Timeline;
using AdminLTEWithASPNETCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Timeline
{
    /// <summary>
    /// Class TimelineItem.
    /// </summary>
    public class TimelineItem
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }
        /// <summary>
        /// Gets or sets the footer.
        /// </summary>
        /// <value>The footer.</value>
        public List<TimelineButton> Footer { get; set; } = new List<TimelineButton>();
        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>The header text.</value>
        public string HeaderText { get; set; }
        /// <summary>
        /// Gets or sets the item icon.
        /// </summary>
        /// <value>The item icon.</value>
        public TimelineItemIcon ItemIcon { get; set; } = TimelineItemIcon.Comment;
        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        public TimelineEventType ItemType { get; set; } = TimelineEventType.UndefinedStatus;
        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>The time.</value>
        public string Time { get; set; }
        /// <summary>
        /// Gets the item icon text.
        /// </summary>
        /// <value>The item icon text.</value>
        public string ItemIconText => ItemIcon.GetDescription();
        /// <summary>
        /// Gets the item type text.
        /// </summary>
        /// <value>The item type text.</value>
        public string ItemTypeText => ItemType.GetDescription();
    }
}
