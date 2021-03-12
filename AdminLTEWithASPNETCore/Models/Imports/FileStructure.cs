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
    }
}