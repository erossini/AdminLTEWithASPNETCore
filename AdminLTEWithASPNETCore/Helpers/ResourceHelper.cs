using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Helpers
{
    public class ResourceHelper
    {
        /// <summary>
        /// Gets the resource lookup.
        /// </summary>
        /// <param name="resourceType">Type of the resource.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>System.String.</returns>
        public static string GetResourceLookup(Type resourceType, string resourceName)
        {
            if ((resourceType != null) && (resourceName != null))
            {
                PropertyInfo property = resourceType.GetProperty(resourceName, BindingFlags.Public | BindingFlags.Static);
                if (property == null)
                {
                    return string.Empty;
                }
                if (property.PropertyType != typeof(string))
                {
                    return string.Empty;
                }

                return (string)property.GetValue(null, null);
            }
            return null;
        }
    }
}
