using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Services.Imports.Models
{
    /// <summary>
    /// Define a generic cell
    /// </summary>
    public class CellDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelCell"/> class.
        /// </summary>
        /// <param name="cellValue">The cell value.</param>
        /// <param name="dataType">Type of the data.</param>
        public CellDef(string cellValue, CellValues dataType)
        {
            CellValue = new CellValue(cellValue);
            DataType = new EnumValue<CellValues>(dataType);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelCell"/> class.
        /// </summary>
        /// <param name="cellValue">The cell value.</param>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="allowNewValues">if set to <c>true</c> [allow new values].</param>
        public CellDef(string cellValue, CellValues dataType, bool allowNewValues)
        {
            CellValue = new CellValue(cellValue);
            DataType = new EnumValue<CellValues>(dataType);
            AllowNewValues = allowNewValues;
        }

        /// <summary>
        /// Gets or sets the cell value.
        /// </summary>
        /// <value>The cell value.</value>
        public CellValue CellValue { get; set; }
        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        public EnumValue<CellValues> DataType { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [allow new values].
        /// </summary>
        /// <value><c>true</c> if [allow new values]; otherwise, <c>false</c>.</value>
        public bool AllowNewValues { get; set; } = false;

        /// <summary>
        /// Creates an Excel cell
        /// </summary>
        /// <returns>Cell.</returns>
        public Cell CreateCell()
        {
            return new Cell()
            {
                CellValue = CellValue,
                DataType = DataType
            };
        }
    }
}