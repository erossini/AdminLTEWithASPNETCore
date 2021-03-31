using PSC.Services.Imports.Models;
using System.Collections.Generic;

namespace AdminLTEWithASPNETCore.Models.Imports
{
    public static class FileStructure
    {
        public static RowDef TestStructure = new RowDef()
        {
            Cells = new List<CellDef>()
            {
                new CellDef("JobNumber", DocumentFormat.OpenXml.Spreadsheet.CellValues.Number),
                new CellDef("Year", DocumentFormat.OpenXml.Spreadsheet.CellValues.Number),
                new CellDef("CampaignType", DocumentFormat.OpenXml.Spreadsheet.CellValues.String)
            }
        };

        /// <summary>
        /// The Azure Report structure (cost report generated from Azure)
        /// </summary>
        public static RowDef AzureReportStructure = new RowDef()
        {
            Cells = new List<CellDef>()
            {
                new CellDef("Resource", DocumentFormat.OpenXml.Spreadsheet.CellValues.String),
                new CellDef("Location", DocumentFormat.OpenXml.Spreadsheet.CellValues.String),
                new CellDef("Resource Group", DocumentFormat.OpenXml.Spreadsheet.CellValues.String),
                new CellDef("Category", DocumentFormat.OpenXml.Spreadsheet.CellValues.String),
                new CellDef("Subcategory", DocumentFormat.OpenXml.Spreadsheet.CellValues.String),
                new CellDef("Quantity", DocumentFormat.OpenXml.Spreadsheet.CellValues.Number),
                new CellDef("Cost (£)", DocumentFormat.OpenXml.Spreadsheet.CellValues.Number)
            }
        };
    }
}