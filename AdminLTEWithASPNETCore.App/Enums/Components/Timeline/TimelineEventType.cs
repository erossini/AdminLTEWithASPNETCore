using System.ComponentModel;

namespace AdminLTEWithASPNETCore.Enums.Components.Timeline
{
    /// <summary>
    /// Enum TimelineEventType
    /// </summary>
    public enum TimelineEventType
    {
        /// <summary>
        /// The other
        /// </summary>
        [Description("bg-purple")]
        Other,
        /// <summary>
        /// The highlight
        /// </summary>
        [Description("bg-maroon")]
        Highlight,
        /// <summary>
        /// The important
        /// </summary>
        [Description("bg-red")]
        Important,
        /// <summary>
        /// The information
        /// </summary>
        [Description("bg-blue")]
        Information,
        /// <summary>
        /// The successful
        /// </summary>
        [Description("bg-green")]
        Successful,
        /// <summary>
        /// The waiting
        /// </summary>
        [Description("bg-gray")]
        UndefinedStatus,
        /// <summary>
        /// The warning
        /// </summary>
        [Description("bg-yellow")]
        Warning
    }
}
