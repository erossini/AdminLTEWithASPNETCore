using Microsoft.AspNetCore.Http;
using PSC.Domain.CommonTables;
using PSC.Domain.Interfaces;
using PSC.Extensions;
using PSC.Persistence.Interfaces;
using PSC.Services.AspNetCore.TableAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.App.Services.Data
{
    public static class CommonTableService<T> where T : class
    {
        /// <summary>
        /// Gets the table azure category.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="form">The form.</param>
        /// <param name="draw">The draw.</param>
        /// <param name="length">The length.</param>
        /// <param name="start">The start.</param>
        /// <param name="columnSort">The column sort.</param>
        /// <param name="columnDirectrion">The column directrion.</param>
        /// <param name="search">The search.</param>
        /// <returns>System.Object.</returns>
        public static object GetTableForUI(IAsyncRepository<T> db, 
            IFormCollection form, string draw, string length, string start,
            string columnSort, string columnDirectrion, string search,
            Expression<Func<T, bool>> exp)
        {
            var customerData = db.ListAllQuerableAsync();

            var service = new TableService<T>();
            var rtn = service.GetRecords(draw, length, start, columnSort, columnDirectrion,
                search, form, customerData, exp);

            return rtn;
        }
    }
}
