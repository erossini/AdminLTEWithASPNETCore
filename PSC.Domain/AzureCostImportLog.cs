using PSC.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Domain
{
    /// <summary>
    /// Class AzureCostImportLog.
    /// </summary>
    [Table("AzureCostImportLogs")]
    public class AzureCostImportLog
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public long ID { get; set; }

        public long AzureCostImportId { get; set; }
        [ForeignKey("AzureCostImportId")]
        public AzureCostImport AzureCostImport { get; set; }

        public DateTime LogData { get; set; } = DateTime.Now;
        public LogType LogType { get; set; }
        public string Message { get; set; }
    }
}
