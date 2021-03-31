using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Settings
{
    /// <summary>
    /// Class AuthenticationSettings.
    /// </summary>
    public class AuthenticationSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether [use identity server].
        /// </summary>
        /// <value><c>true</c> if [use identity server]; otherwise, <c>false</c>.</value>
        public bool UseIdentityServer { get; set; }
        /// <summary>
        /// Gets or sets the identity server.
        /// </summary>
        /// <value>The identity server.</value>
        public IdentityserverSettings IdentityServer { get; set; }
        /// <summary>
        /// Gets or sets the facebook.
        /// </summary>
        /// <value>The facebook.</value>
        public FacebookSettings Facebook { get; set; }
        /// <summary>
        /// Gets or sets the google.
        /// </summary>
        /// <value>The google.</value>
        public GoogleSettings Google { get; set; }
        /// <summary>
        /// Gets or sets the microsoft.
        /// </summary>
        /// <value>The microsoft.</value>
        public MicrosoftSettings Microsoft { get; set; }
        /// <summary>
        /// Gets or sets the twitter.
        /// </summary>
        /// <value>The twitter.</value>
        public TwitterSettings Twitter { get; set; }
    }
}