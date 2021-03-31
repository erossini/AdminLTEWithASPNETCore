using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Enums.Components
{
    /// <summary>
    /// Enum PositionType
    /// </summary>
    public enum PositionType
    {
        /// <summary>
        /// The bottom
        /// </summary>
        [Description("bottom")]
        Bottom,
        /// <summary>
        /// The left
        /// </summary>
        [Description("left")] 
        Left,
        /// <summary>
        /// The right
        /// </summary>
        [Description("right")] 
        Right,
        /// <summary>
        /// The top
        /// </summary>
        [Description("top")]
        Top
    }
}
