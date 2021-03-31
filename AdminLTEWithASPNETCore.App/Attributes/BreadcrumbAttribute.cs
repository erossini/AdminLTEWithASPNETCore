// ***********************************************************************
// Assembly         : AdminLTEWithASPNETCore
// Author           : Enrico Rossini
// Blog             : PureSourceCode
// Blog URL         : https://www.puresourcecode.com/
// Created          : 12-18-2020
//
// Last Modified By : Enrico Rossini
// Last Modified On : 12-21-2020
// ***********************************************************************
// <copyright file="BreadcrumbAttribute.cs" company="AdminLTEWithASPNETCore">
//     Copyright (c) PureSourceCode. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AdminLTEWithASPNETCore.Helpers;
using System;

namespace AdminLTEWithASPNETCore.Attributes
{
    /// <summary>Class BreadcrumbAttribute.
    /// Implements the <see cref="System.Attribute" /></summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true)]
    public class BreadcrumbAttribute : Attribute
    {
        /// <summary>Initializes a new instance of the <see cref="T:AdminLTEWithASPNETCore.Attributes.BreadcrumbAttribute" /> class.</summary>
        /// <param name="label">The label.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="passArgs">if set to <c>true</c> [pass arguments].</param>
        public BreadcrumbAttribute(string label, string controller = "", string action = "", bool passArgs = false)
        {
            Label = label;
            ControllerName = controller;
            ActionName = action;
            PassArguments = passArgs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BreadcrumbAttribute"/> class.
        /// </summary>
        /// <param name="resourceType">Type of the resource.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="passArgs">if set to <c>true</c> [pass arguments].</param>
        public BreadcrumbAttribute(Type resourceType, string resourceName, string controller = "", string action = "", bool passArgs = false)
        {
            Label = ResourceHelper.GetResourceLookup(resourceType, resourceName);
            ControllerName = controller;
            ActionName = action;
            PassArguments = passArgs;
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label { get; }

        /// <summary>
        /// Gets the name of the controller.
        /// </summary>
        /// <value>The name of the controller.</value>
        public string ControllerName { get; }

        /// <summary>
        /// Gets the name of the action.
        /// </summary>
        /// <value>The name of the action.</value>
        public string ActionName { get; }

        /// <summary>
        /// Gets a value indicating whether [pass arguments].
        /// </summary>
        /// <value><c>true</c> if [pass arguments]; otherwise, <c>false</c>.</value>
        public bool PassArguments { get; }
    }
}