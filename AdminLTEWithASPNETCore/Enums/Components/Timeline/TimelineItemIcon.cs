using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Enums.Components.Timeline
{
    /// <summary>
    /// Enum TimelineItemIcon
    /// </summary>
    public enum TimelineItemIcon
    {
        /// <summary>
        /// The comment
        /// </summary>
        [Description("fa-comment")]
        Comment,
        /// <summary>
        /// The letter
        /// </summary>
        [Description("fa-envelope")]
        Letter,
        /// <summary>
        /// The user activity
        /// </summary>
        [Description("fa-user")]
        UserActivity,
        /// <summary>
        /// The wait
        /// </summary>
        [Description("fa-clock")]
        Wait
    }
}
