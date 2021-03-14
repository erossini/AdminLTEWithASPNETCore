using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PSC.Services.Imports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Services.Imports
{
    /// <summary>
    /// Class ImportExcel.
    /// </summary>
    public class ImportExcel
    {
        /// <summary>
        /// Validates the header.
        /// </summary>
        /// <param name="dataGrid">The data grid.</param>
        /// <param name="rowDef">The row definition.</param>
        /// <returns>System.ValueTuple&lt;System.Boolean, List&lt;System.String&gt;&gt;.</returns>
        public (bool IsValid, List<string> Errors) ValidateHeader(DataGrid dataGrid, RowDef rowDef)
        {
            bool rtn = true;
            List<string> errs = new List<string>();

            foreach (CellDef cell in rowDef.Cells)
            {
                if (dataGrid.Headers.Where(h => h == cell.CellValue.Text).Count() == 0)
                {
                    rtn = false;
                    errs.Add($"The field {cell.CellValue.Text} is not present in the Excel file");
                }
            }

            return (rtn, errs);
        }

        /// <summary>
        /// Reads to grid.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>DataGrid.</returns>
        public DataGrid ReadToGrid(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            var grid = new DataGrid();
            grid.Success = true;

            var document = SpreadsheetDocument.Open(filePath, false);
            var sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;
            var value = string.Empty;

            bool isheader = true;
            foreach (var worksheetPart in document.WorkbookPart.WorksheetParts)
            {
                foreach (var sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                {
                    if (sheetData.HasChildren)
                    {
                        foreach (var row in sheetData.Elements<Row>())
                        {
                            int columnIndex = 0;
                            var dictionary = new Dictionary<string, string>();

                            foreach (var cell in row.Elements<Cell>())
                            {
                                value = cell.InnerText;

                                if (value != null && cell.DataType != null && cell.DataType == CellValues.SharedString)
                                    value = sharedStringTable.ElementAt(int.Parse(value)).InnerText;

                                if (isheader)
                                {
                                    grid.Headers.Add(value);
                                }
                                else
                                {
                                    var header = grid.Headers[columnIndex];
                                    dictionary.Add(header, value);
                                }

                                columnIndex++;
                            }

                            if (!isheader)
                                grid.Rows.Add(dictionary);

                            isheader = false;
                        }
                    }
                }
            }

            document.Close();

            // TODO: check if some columns are missing because blank in the Excel file
            return grid;
        }
    }
}