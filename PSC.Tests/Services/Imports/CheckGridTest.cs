using NUnit.Framework;
using PSC.Services.Imports;
using PSC.Services.Imports.Models;
using System.Collections.Generic;

namespace PSC.Tests.Services.Imports
{
    [TestFixture]
    public class CheckGridTest
    {
        private int nRows = 10;
        private DataGrid dgInput1;
        private DataGrid dbExpect1;
        private DataGrid dgInput2;
        private DataGrid dbExpect2;

        [Test]
        [SetUp]
        public void CreateData()
        {
            dgInput1 = new DataGrid();
            dbExpect1 = new DataGrid();
            dgInput2 = new DataGrid();
            dbExpect2 = new DataGrid();

            List<string> headers = new List<string>() {
                "Resource", "Location", "Resource Group", "Category", "Subcategory", "Quantity", "Cost(£)"
            };

            dgInput1.Headers.AddRange(headers);
            dgInput2.Headers.AddRange(headers);

            dbExpect1.Headers.AddRange(headers);
            dbExpect2.Headers.AddRange(headers);

            for (int i = 0; i < nRows; i++)
            {
                int pos = 0;
                Dictionary<string, string> dictInput = new Dictionary<string, string>();
                Dictionary<string, string> dictExpect = new Dictionary<string, string>();

                foreach (var item in dgInput1.Headers)
                {
                    if (pos != i)
                    {
                        dictInput.Add(item, $"Test-{i}-{pos}");
                        dictExpect.Add(item, $"Test-{i}-{pos}");
                    }
                    else
                    {
                        dictExpect.Add(item, "");
                    }
                    pos++;
                }

                dgInput1.Rows.Add(dictInput);
                dbExpect1.Rows.Add(dictExpect);
            }

            Dictionary<string, string> dictInput2 = new Dictionary<string, string>();
            Dictionary<string, string> dictExpect2 = new Dictionary<string, string>();

            // generic row
            //dictInput2.Add("Resource", "");
            //dictInput2.Add("Location", "");
            //dictInput2.Add("Resource Group", "");
            //dictInput2.Add("Category", "");
            //dictInput2.Add("Subcategory", "");
            //dictInput2.Add("Quantity", "");
            //dictInput2.Add("Cost(£)", "");
            //dgInput2.Rows.Add(dictInput2);
            //dbExpect2.Rows.Add(dictExpect2);

            // first row
            dictInput2.Add("Resource", "F1");
            dictInput2.Add("Resource Group", "akuks");
            dictInput2.Add("Category", "Azure App Service");
            dictInput2.Add("Subcategory", "Azure App Service");
            dictInput2.Add("Quantity", "3");
            dictInput2.Add("Cost(£)", "0");

            dictExpect2.Add("Resource", "F1");
            dictExpect2.Add("Location", "");
            dictExpect2.Add("Resource Group", "akuks");
            dictExpect2.Add("Category", "Azure App Service");
            dictExpect2.Add("Subcategory", "Azure App Service");
            dictExpect2.Add("Quantity", "3");
            dictExpect2.Add("Cost(£)", "0");
            dgInput2.Rows.Add(dictInput2);
            dbExpect2.Rows.Add(dictExpect2);

            // second row
            dictInput2 = new Dictionary<string, string>();
            dictExpect2 = new Dictionary<string, string>();
            dictInput2.Add("Resource", "All other operation");
            dictInput2.Add("Location", "UKSOUTH");
            dictInput2.Add("Resource Group", "akuks");
            dictInput2.Add("Subcategory", "Blob Storage");
            dictInput2.Add("Quantity", "0.0191");
            dictInput2.Add("Cost(£)", "0.00004");

            dictExpect2.Add("Resource", "All other operation");
            dictExpect2.Add("Location", "UKSOUTH");
            dictExpect2.Add("Resource Group", "akuks");
            dictExpect2.Add("Category", "");
            dictExpect2.Add("Subcategory", "Blob Storage");
            dictExpect2.Add("Quantity", "0.0191");
            dictExpect2.Add("Cost(£)", "0.00004");
            dgInput2.Rows.Add(dictInput2);
            dbExpect2.Rows.Add(dictExpect2);
        }

        [Test]
        public void CheckGridResult()
        {
            ImportExcel _excel = new ImportExcel();
            var result = _excel.CheckGrid(dgInput1);

            Assert.That(result.Rows, Is.EquivalentTo(dbExpect1.Rows)
                  .Using<KeyValuePair<string, int>, KeyValuePair<string, string>>((actual, expected)
                        => actual.Key.Equals(expected.Key) && actual.Value.ToString().Equals(expected.Value)));
        }

        [Test]
        public void CheckGridResult2()
        {
            ImportExcel _excel = new ImportExcel();
            var result = _excel.CheckGrid(dgInput2);

            Assert.That(result.Rows, Is.EquivalentTo(dbExpect2.Rows)
                  .Using<KeyValuePair<string, int>, KeyValuePair<string, string>>((actual, expected)
                        => actual.Key.Equals(expected.Key) && actual.Value.ToString().Equals(expected.Value)));
        }
    }
}