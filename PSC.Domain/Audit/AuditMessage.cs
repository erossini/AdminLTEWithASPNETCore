using PSC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Domain.Audit
{
    /// <summary>
    /// Class AuditMessage.
    /// Implements the <see cref="PSC.Domain.Interfaces.IAudit" />
    /// </summary>
    /// <seealso cref="PSC.Domain.Interfaces.IAudit" />
    public class AuditMessage : IAudit
    {
        /// <summary>
        /// Gets or sets the audit identifier.
        /// </summary>
        /// <value>The audit identifier.</value>
        [Key]
        public long AuditId { get; set; }

        /// <summary>
        /// Gets or sets the identifier message.
        /// </summary>
        /// <value>The identifier message.</value>
        public long IdMessage { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the receiver identifier.
        /// </summary>
        /// <value>The receiver identifier.</value>
        public string ReceiverId { get; set; }

        /// <summary>
        /// Gets or sets the sender identifier.
        /// </summary>
        /// <value>The sender identifier.</value>
        public string SenderId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; } = "Unread";

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        public string Priority { get; set; } = "Normal";

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        public bool IsNew { get; set; } = true;

        /// <summary>
        /// Gets or sets the audit action.
        /// </summary>
        /// <value>The audit action.</value>
        public string AuditAction { get; set; }
        /// <summary>
        /// Gets or sets the audit date.
        /// </summary>
        /// <value>The audit date.</value>
        public DateTime AuditDate { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
    }
}
