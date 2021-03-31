using AdminLTEWithASPNETCore.Enums.Components.Timeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Components.Timeline
{
    /// <summary>
    /// Class TimelineModel.
    /// </summary>
    public class TimelineModel
    {
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        public List<TimelineEvent> Events { get; set; } = new List<TimelineEvent>();
    }
}
