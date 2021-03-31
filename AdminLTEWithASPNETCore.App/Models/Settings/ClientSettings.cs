using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Settings
{
    /// <summary>
    /// Class ClientSettings.
    /// </summary>
    public class ClientSettings
    {
        /// <summary>
        /// Gets or sets the client identifier. ClientId is also AppId for Faceboook and ConsumerAPIKey for Twitter
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets the client secret. ClientSecret is also AppSecret for Facebook and ConsumerSecret for Twitter
        /// </summary>
        /// <value>The client secret.</value>
        public string ClientSecret { get; set; }
    }
}
