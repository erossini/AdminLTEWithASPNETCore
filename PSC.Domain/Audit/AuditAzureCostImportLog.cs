using PSC.Domain.Enums;
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
    public class AuditAzureCostImportLog
    {
        /// <summary>
        /// Gets or sets the audit identifier.
        /// </summary>
        /// <value>The audit identifier.</value>
        [Key]
        public long AuditId { get; set; }

        public long ID { get; set; }

        public long AzureCostImportId { get; set; }

        public DateTime LogData { get; set; } = DateTime.Now;
        public LogType LogType { get; set; }
        public string Message { get; set; }

        public string AuditAction { get; set; }
        public DateTime AuditDate { get; set; }
        public string UserName { get; set; }
    }
}
