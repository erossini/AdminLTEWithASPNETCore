using PSC.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSC.Domain.CommonTables
{
    /// <summary>
    /// Class Country.
    /// </summary>
    [Table("tbl_Countries")]
    public class Country : ITable
    {
        /// <summary>
        /// Gets or sets the identifier country.
        /// </summary>
        /// <value>The identifier country.</value>
        [Key]
        public long ID { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [StringLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        public int Order { get; set; } = 0;
    }
}
