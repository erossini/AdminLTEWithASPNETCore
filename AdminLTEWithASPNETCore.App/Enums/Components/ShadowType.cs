using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Enums.Components
{
    /// <summary>
    /// Enum ShadowType
    /// </summary>
    public enum ShadowType
    {
        /// <summary>
        /// The none
        /// </summary>
        [Description("")]
        None,
        /// <summary>
        /// The small
        /// </summary>
        [Description("shadow-sm")]
        Small,
        /// <summary>
        /// The regular
        /// </summary>
        [Description("shadow")]
        Regular,
        /// <summary>
        /// The large
        /// </summary>
        [Description("shadow-lg")]
        Large
    }
}
