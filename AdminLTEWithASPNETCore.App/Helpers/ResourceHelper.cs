// ***********************************************************************
// Assembly         : AdminLTEWithASPNETCore
// Author           : Enrico Rossini
// Blog             : PureSourceCode
// Blog URL         : https://www.puresourcecode.com/
// Created          : 12-19-2020
//
// Last Modified By : Enrico Rossini
// Last Modified On : 12-21-2020
// ***********************************************************************
// <copyright file="ResourceHelper.cs" company="AdminLTEWithASPNETCore">
//     Copyright (c) PureSourceCode. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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