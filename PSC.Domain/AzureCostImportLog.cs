using PSC.Domain.Enums;
using PSC.Domain.Interfaces;
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
    public class AzureCostImportLog : ITable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public long AzureCostImportId { get; set; }
        [ForeignKey("AzureCostImportId")]
        public AzureCostImport AzureCostImport { get; set; }

        public DateTime LogData { get; set; } = DateTime.Now;
        public LogType LogType { get; set; } = LogType.Information;
        public string Message { get; set; }
        public string Username { get; set; }
    }
}
