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
    [Table("Audit_AzureCosts")]
    public class AuditAzureCost : IAudit
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
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        public long ResourceId { get; set; }
        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>The location identifier.</value>
        public long LocationId { get; set; }
        /// <summary>
        /// Gets or sets the resource group identifier.
        /// </summary>
        /// <value>The resource group identifier.</value>
        public long ResourceGroupId { get; set; }
        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public long CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the subcategory identifier.
        /// </summary>
        /// <value>The subcategory identifier.</value>
        public long SubcategoryId { get; set; }
        /// <summary>
        /// Gets or sets the azure cost import identifier.
        /// </summary>
        /// <value>The azure cost import identifier.</value>
        public long AzureCostImportId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public decimal Cost { get; set; }
        public DateTime ImportDate { get; set; } = DateTime.Now;

        public string AuditAction { get; set; }
        public DateTime AuditDate { get; set; }
        public string UserName { get; set; }
    }
}