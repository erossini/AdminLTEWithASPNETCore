using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Settings
{
    /// <summary>
    /// Class IdentityserverSettings.
    /// Implements the <see cref="AdminLTEWithASPNETCore.Models.Settings.ClientSettings" />
    /// </summary>
    /// <seealso cref="AdminLTEWithASPNETCore.Models.Settings.ClientSettings" />
    public class IdentityserverSettings : ClientSettings
    {
        /// <summary>
        /// Gets or sets the identity server URL.
        /// </summary>
        /// <value>The identity server URL.</value>
        public string IdentityServerUrl { get; set; }
    }
}
