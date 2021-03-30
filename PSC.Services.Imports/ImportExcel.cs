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
                                    int cellRef = CellReferenceToIndex(cell);
                                    var header = grid.Headers[cellRef];
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
            return CheckGrid(grid);
        }

        /// <summary>
        /// Checks the grid.
        /// </summary>
        /// <param name="grid">The grid.</param>
        /// <returns>DataGrid.</returns>
        public DataGrid CheckGrid(DataGrid grid)
        {
            DataGrid rtn = new DataGrid();
            rtn.Headers.AddRange(grid.Headers);
            rtn.Success = grid.Success;

            int nColumns = grid.Headers.Count;

            foreach (var item in grid.Rows)
            {
                if (item.Count == nColumns)
                    rtn.Rows.Add(item);
                else
                {
                    var dictionary = new Dictionary<string, string>();

                    foreach (var head in rtn.Headers)
                    {
                        string value = item.ContainsKey(head) ? item[head] : "";
                        dictionary.Add(head, value);
                    }

                    rtn.Rows.Add(dictionary);
                }
            }

            return rtn;
        }

        /// <summary>Cells the index of the reference to.</summary>
        /// <param name="cell">The cell.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>
        /// The moment you have even a single empty cell in a row then things go haywire. 
        /// Essentially we need to figure out the original column index of the cell in case there were empty cells before it. 
        /// This function obtains the original/correct index of any cell.
        /// </remarks>
        private static int CellReferenceToIndex(Cell cell)
        {
            int index = 0;
            string reference = cell.CellReference.ToString().ToUpper();
            foreach (char ch in reference)
            {
                if (Char.IsLetter(ch))
                {
                    int value = (int)ch - (int)'A';
                    index = (index == 0) ? value : ((index + 1) * 26) + value;
                }
                else
                {
                    return index;
                }
            }
            return index;
        }
    }
}