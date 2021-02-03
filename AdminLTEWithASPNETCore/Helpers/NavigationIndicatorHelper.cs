// ***********************************************************************
// Assembly         : AdminLTEWithASPNETCore
// Author           : Enrico Rossini
// Blog             : PureSourceCode
// Blog URL         : https://www.puresourcecode.com/
// Created          : 12-18-2020
//
// Last Modified By : Enrico Rossini
// Last Modified On : 01-21-2021
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
                if (urlHelper.ActionContext.RouteData.Values["controller"] == null)
                    return null;

                string result = "active";
                string controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
                string methodName = urlHelper.ActionContext.RouteData.Values["action"].ToString();
                if (string.IsNullOrEmpty(controllerName)) return null;
                if (controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
                    if (methodName.Equals(action, StringComparison.OrdinalIgnoreCase))
                        return result;

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Checks area and page with the current route data.
        /// If they match, it returns a string “active”, else null.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="area">The area.</param>
        /// <param name="page">The page.</param>
        /// <returns>System.String.</returns>
        public static string MakeAreaActiveClass(this IUrlHelper urlHelper, string area, string page)
        {
            try
            {
                if (urlHelper.ActionContext.RouteData.Values["area"] == null)
                    return null;

                string result = "active";
                string areaName = urlHelper.ActionContext.RouteData.Values["area"].ToString();
                string pageName = urlHelper.ActionContext.RouteData.Values["page"].ToString();
                if (string.IsNullOrEmpty(areaName)) return null;
                if (areaName.Equals(area, StringComparison.OrdinalIgnoreCase))
                    if (pageName.Equals(page, StringComparison.OrdinalIgnoreCase))
                        return result;

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Makes the area menu open class.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="area">The area.</param>
        /// <returns>System.String.</returns>
        public static string MakeAreaMenuOpenClass(this IUrlHelper urlHelper, string area)
        {
            try
            {
                if (urlHelper.ActionContext.RouteData.Values["area"] == null)
                    return null;

                string result = "menu-is-opening menu-open";
                string controllerName = urlHelper.ActionContext.RouteData.Values["area"].ToString();
                if (string.IsNullOrEmpty(controllerName)) return null;
                if (controllerName.Equals(area, StringComparison.OrdinalIgnoreCase))
                    return result;

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
