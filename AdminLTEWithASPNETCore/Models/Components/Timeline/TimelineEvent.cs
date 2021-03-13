using AdminLTEWithASPNETCore.Enums.Components.Timeline;
using AdminLTEWithASPNETCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Timeline
{
    public class TimelineEvent
    {
        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>The event date.</value>
        public string EventDate { get; set; }
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        public TimelineEventType EventType { get; set; } = TimelineEventType.UndefinedStatus;
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<TimelineItem> Items { get; set; } = new List<TimelineItem>();
        /// <summary>
        /// Gets the event type CSS.
        /// </summary>
        /// <value>The event type CSS.</value>
        public string EventTypeText => EventType.GetDescription();
    }
}