// ***********************************************************************
// Assembly         : AdminLTEWithASPNETCore
// Author           : Enrico Rossini
// Blog             : PureSourceCode
// Blog URL         : https://www.puresourcecode.com/
// Created          : 12-19-2020
//
// Last Modified By : Enrico Rossini
// Last Modified On : 12-19-2020
// ***********************************************************************
// <copyright file="HtmlExtensions.cs" company="AdminLTEWithASPNETCore">
//     Copyright (c) PureSourceCode. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AdminLTEWithASPNETCore.Attributes;
using AdminLTEWithASPNETCore.Models.UI;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AdminLTEWithASPNETCore.Extensions
{
    public static class HtmlExtensions
    {
        private static readonly HtmlContentBuilder _emptyBuilder = new HtmlContentBuilder();

        /// <summary>
        /// Builds the breadcrumb navigation.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="breadcrumbExtras">
        /// This values are appended between the controller and the page's title
        /// </param>
        /// <returns>IHtmlContent.</returns>
        public static IHtmlContent BuildBreadcrumbNavigation(this IHtmlHelper helper, List<BreadcrumbItem> breadcrumbExtras)
        {
            IHtmlContentBuilder rtn = null;

            if (helper.ViewContext.RouteData.Values["controller"] == null)
                return null;

            string controllerName = helper.ViewContext.RouteData.Values["controller"].ToString();
            string actionName = helper.ViewContext.RouteData.Values["action"].ToString();
            string query = helper.ViewContext.HttpContext.Request.QueryString.Value;

            var type = typeof(Microsoft.AspNetCore.Mvc.Controller);
            var controllersTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsSubclassOf(type))
                .ToList();

            var urlHelperFactory = helper.ViewContext.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
            var urlHelper = urlHelperFactory.GetUrlHelper(helper.ViewContext);
            var homeLink = urlHelper.Action("Index", "Home");
            var breadcrumb = new HtmlContentBuilder()
                                .AppendHtml("<ol class='breadcrumb float-sm-right'><li class='breadcrumb-item'>")
                                .AppendHtml($"<a href='{homeLink}'><i class='fas fa-home'></i></a>")
                                .AppendHtml("</li>");

            var controllerType = controllersTypes.FirstOrDefault(x => x.Name == $"{controllerName}Controller");
            if (controllerType != null)
            {
                var breadcrumbControllerAttributes = controllerType.GetCustomAttributes<BreadcrumbAttribute>();
                if (breadcrumbControllerAttributes != null && breadcrumbControllerAttributes.Any())
                {
                    foreach (var bs in breadcrumbControllerAttributes)
                    {
                        breadcrumb.AppendHtml(BuildBreadcrumb(bs, urlHelper, query));
                    }
                }

                if (breadcrumbExtras != null && breadcrumbExtras.Any())
                {
                    foreach (var be in breadcrumbExtras)
                    {
                        breadcrumb.AppendHtml(BuildBreadcrumb(be));
                    }
                }
                else
                {
                    var actionProp = controllerType.GetTypeInfo().GetMethods()
                        .FirstOrDefault(x => x.Name == actionName && x.CustomAttributes.Any(y => y.AttributeType == typeof(BreadcrumbAttribute)));
                    var breadcrumbMethodsAttributes = actionProp?.GetCustomAttributes<BreadcrumbAttribute>();

                    if (breadcrumbMethodsAttributes != null && breadcrumbMethodsAttributes.Any())
                    {
                        foreach (var bs in breadcrumbMethodsAttributes)
                        {
                            breadcrumb.AppendHtml(BuildBreadcrumb(bs, urlHelper, query));
                        }
                    }
                }
            }
            rtn = breadcrumb.AppendHtml("</ol>");

            return rtn;
        }

        private static string BuildBreadcrumb(BreadcrumbAttribute bs, IUrlHelper urlHelper, string parameters)
        {
            string link = "<li class='breadcrumb-item'>";

            if (!string.IsNullOrEmpty(bs.ActionName) && !string.IsNullOrEmpty(bs.ControllerName))
                link += $"<a href='{urlHelper.AbsoluteAction(bs.ActionName, bs.ControllerName)}{(bs.PassArguments ? parameters : string.Empty)}'>{bs.Label}</a>";
            else
                link += bs.Label;

            link += "</li>";

            return link;
        }

        private static string BuildBreadcrumb(BreadcrumbItem bs)
        {
            string link = "<li class='breadcrumb-item'>";

            if (!string.IsNullOrEmpty(bs.URL))
                link += $"<a href='{bs.URL}'>{bs.Label}</a>";
            else
                link += bs.Label;

            link += "</li>";

            return link;
        }
    }
}