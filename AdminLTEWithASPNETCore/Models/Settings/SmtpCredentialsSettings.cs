using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.Settings
{
    /// <summary>
    /// Class SmtpCredentialsSettings.
    /// </summary>
    public class SmtpCredentialsSettings
    {
        /// <summary>
        /// Gets or sets the mail from.
        /// </summary>
        /// <value>The mail from.</value>
        public string MailFrom { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        public string Server { get; set; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
        public int Port { get; set; }
        /// <summary>
        /// Gets or sets the enable SSL.
        /// </summary>
        /// <value>The enable SSL.</value>
        public bool EnableSSL { get; set; }
    }
}
