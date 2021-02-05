using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Settings
{
    /// <summary>
    /// Class IdentityServerSettings.
    /// </summary>
    public class IdentityServerSettings
    {
        /// <summary>
        /// Gets or sets the identity server URL.
        /// </summary>
        /// <value>The identity server URL.</value>
        public string IdentityServerUrl { get; set; }
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets the client password.
        /// </summary>
        /// <value>The client password.</value>
        public string ClientSecret { get; set; }
    }
}