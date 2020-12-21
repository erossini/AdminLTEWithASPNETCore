// ***********************************************************************
// Assembly         : AdminLTEWithASPNETCore
// Author           : Enrico Rossini
// Blog             : PureSourceCode
// Blog URL         : https://www.puresourcecode.com/
// Created          : 12-18-2020
//
// Last Modified By : Enrico Rossini
// Last Modified On : 12-18-2020
// ***********************************************************************
// <copyright file="NavigationIndicatorHelper.cs" company="AdminLTEWithASPNETCore">
//     Copyright (c) PureSourceCode. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Helpers
{
    /// <summary>
    /// Class NavigationIndicatorHelper
    /// </summary>
    public static class NavigationIndicatorHelper
    {
        /// <summary>
        /// Checks controller and action with the current route data.
        /// If they match, it returns a string “active”, else null.
        /// </summary>
        /// <param name="urlHelper"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns>"active" if controller and action match, null in other cases</returns>
        public static string MakeActiveClass(this IUrlHelper urlHelper, string controller, string action)
        {
            try
            {
                string result = "active";
                string controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
                string methodName = urlHelper.ActionContext.RouteData.Values["action"].ToString();
                if (string.IsNullOrEmpty(controllerName)) return null;
                if (controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
                {
                    if (methodName.Equals(action, StringComparison.OrdinalIgnoreCase))
                    {
                        return result;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
