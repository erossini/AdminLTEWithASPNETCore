using PSC.Domain.Enums;
using PSC.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSC.Domain
{
    /// <summary>
    /// Class AzureCostImportLog.
    /// </summary>
    [Table("AzureCostImportLogs")]
    public class AzureCostImportLog : ITable
    {
        #region ITable implementation

        /// <summary>
        /// Gets or sets the identifier country.
        /// </summary>
        /// <value>The identifier country.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        #endregion ITable implementation

        public long AzureCostImportId { get; set; }

        [ForeignKey("AzureCostImportId")]
        public AzureCostImport AzureCostImport { get; set; }

        public DateTime LogData { get; set; } = DateTime.Now;
        public LogType LogType { get; set; } = LogType.Information;
        public string Body { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}