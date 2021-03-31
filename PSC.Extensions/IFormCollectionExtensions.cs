using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PSC.Extensions
{
    public static class IFormCollectionExtensions
    {
        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        public static string GetValueOrDefault(this IFormCollection form, string key, string defaultValue)
        {
            string rtn = form[key].FirstOrDefault();
            if (string.IsNullOrEmpty(rtn) && !string.IsNullOrEmpty(defaultValue))
                rtn = defaultValue;

            return rtn;
        }
    }
}