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
    /// Class AzureCostImportFile.
    /// </summary>
    [Table("AzureCostImports")]
    public class AzureCostImport : ITable
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

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
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string UserId { get; set; }
        /// <summary>
        /// Gets or sets the import logs.
        /// </summary>
        /// <value>The import logs.</value>
        public virtual ICollection<AzureCostImportLog> ImportLogs { get; set; }
    }
}