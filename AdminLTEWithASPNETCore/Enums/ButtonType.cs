using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Enums
{
    /// <summary>
    /// Enum TimelineButtonType
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// The default
        /// </summary>
        [Description("btn-default")]
        Default,
        /// <summary>
        /// The danger
        /// </summary>
        [Description("btn-danger")]
        Danger,
        /// <summary>
        /// The information
        /// </summary>
        [Description("btn-info")]
        Info,
        /// <summary>
        /// The primary
        /// </summary>
        [Description("btn-primary")]
        Primary,
        /// <summary>
        /// The secondary
        /// </summary>
        [Description("btn-secondary")]
        Secondary,
        /// <summary>
        /// The success
        /// </summary>
        [Description("btn-success")]
        Success,
        /// <summary>
        /// The warning
        /// </summary>
        [Description("btn-warning")]
        Warning
    }
}
