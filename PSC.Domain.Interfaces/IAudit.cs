using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Domain.Interfaces
{
    /// <summary>
    /// Interface IAudit
    /// </summary>
    public interface IAudit
    {
        /// <summary>
        /// Gets or sets the audit action.
        /// </summary>
        /// <value>The audit action.</value>
        string AuditAction { get; set; }
        /// <summary>
        /// Gets or sets the audit date.
        /// </summary>
        /// <value>The audit date.</value>
        DateTime AuditDate { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        string UserName { get; set; }
    }
}