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
    /// <summary>
    /// Class AuditAzureCostImport.
    /// Implements the <see cref="PSC.Domain.Interfaces.IAudit" />
    /// </summary>
    /// <seealso cref="PSC.Domain.Interfaces.IAudit" />
    [Table("Audit_AzureCostImports")]
    public class AuditAzureCostImport : IAudit
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

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        public string Period { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }

        public string AuditAction { get; set; }
        public DateTime AuditDate { get; set; }
        public string UserName { get; set; }
    }
}
