using Microsoft.AspNetCore.Http;
using PSC.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PSC.Services.AspNetCore.TableAPIs
{
    /// <summary>
    /// Class TableService.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TableService<T> where T : class
    {
        public object GetRecords(string draw, string length, string start, string columnSort,
            string columnDirectrion, string search, IFormCollection form, IQueryable<T> data,
            Expression<Func<T, bool>> condition)
        {
            var drawValue = form.GetValueOrDefault("draw", draw);
            var lengthValue = form.GetValueOrDefault("length", length);
            var startValue = form.GetValueOrDefault("start", start);
            var sortColumn = columnSort ?? form["columns[" + form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = form.GetValueOrDefault("order[0][dir]", columnDirectrion);
            var searchValue = form.GetValueOrDefault("search[value]", search);

            int pageSize = !string.IsNullOrEmpty(length) ? Convert.ToInt32(lengthValue) : 10;
            int skip = !string.IsNullOrEmpty(start) ? Convert.ToInt32(startValue) : 0;

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                data = data.OrderBy(sortColumn + " " + sortColumnDirection);

            if (!string.IsNullOrEmpty(searchValue))
                data = data.Where(condition);

            var recordsTotal = data.Count();

            var rtn = data.Skip(skip).Take(pageSize);
            var jsonData = new { draw = drawValue, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = rtn };
            return jsonData;
        }
    }
}