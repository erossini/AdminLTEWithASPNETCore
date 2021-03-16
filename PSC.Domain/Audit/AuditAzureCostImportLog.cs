using PSC.Domain.Enums;
using PSC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Domain.Audit
{
    [Table("Audit_AzureCostImportLogs")]
    public class AuditAzureCostImportLog: IAudit
    {
        /// <summary>
        /// Gets or sets the audit identifier.
        /// </summary>
        /// <value>The audit identifier.</value>
        [Key]
        public long AuditId { get; set; }

        #region ITable implementation
        /// <summary>
        /// Gets or sets the identifier country.
        /// </summary>
        /// <value>The identifier country.</value>
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the modified at.
        /// </summary>
        /// <value>The modified at.</value>
        public DateTime? ModifiedAt { get; set; }
        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>The modified by.</value>
        public string ModifiedBy { get; set; }
        #endregion

        public long AzureCostImportId { get; set; }

        public DateTime LogData { get; set; } = DateTime.Now;
        public LogType LogType { get; set; }
        public string Body { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }

        public string AuditAction { get; set; }
        public DateTime AuditDate { get; set; }
        public string UserName { get; set; }
    }
}
