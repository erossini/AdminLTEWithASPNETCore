﻿using PSC.Domain.CommonTables;
using PSC.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSC.Domain
{
    /// <summary>
    /// Class AzureCost.
    /// </summary>
    [Table("AzureCosts")]
    public class AzureCost : ITable
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

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        /// <value>The resource identifier.</value>
        public long? ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the azure resource.
        /// </summary>
        /// <value>The azure resource.</value>
        [ForeignKey("ResourceId")]
        public virtual AzureResource AzureResource { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>The location identifier.</value>
        public long? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the azure location.
        /// </summary>
        /// <value>The azure location.</value>
        [ForeignKey("LocationId")]
        public virtual AzureLocation AzureLocation { get; set; }

        /// <summary>
        /// Gets or sets the resource group identifier.
        /// </summary>
        /// <value>The resource group identifier.</value>
        public long? ResourceGroupId { get; set; }

        /// <summary>
        /// Gets or sets the azure resource group.
        /// </summary>
        /// <value>The azure resource group.</value>
        [ForeignKey("ResourceGroupId")]
        public virtual AzureResourceGroup AzureResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>The category identifier.</value>
        public long? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the azure category.
        /// </summary>
        /// <value>The azure category.</value>
        [ForeignKey("CategoryId")]
        public virtual AzureCategory AzureCategory { get; set; }

        /// <summary>
        /// Gets or sets the subcategory identifier.
        /// </summary>
        /// <value>The subcategory identifier.</value>
        public long? SubcategoryId { get; set; }

        /// <summary>
        /// Gets or sets the azure subcategory.
        /// </summary>
        /// <value>The azure subcategory.</value>
        [ForeignKey("SubcategoryId")]
        public virtual AzureSubcategory AzureSubcategory { get; set; }

        public long? AzureCostImportId { get; set; }

        [ForeignKey("AzureCostImportId")]
        public virtual AzureCostImport AzureCostImport { get; set; }

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

        /// <summary>
        /// Gets or sets the import date.
        /// </summary>
        /// <value>The import date.</value>
        public DateTime ImportDate { get; set; } = DateTime.Now;
    }
}