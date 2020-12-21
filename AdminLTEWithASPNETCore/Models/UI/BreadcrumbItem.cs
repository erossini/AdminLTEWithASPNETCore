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
// <copyright file="BreadcrumbItem.cs" company="AdminLTEWithASPNETCore">
//     Copyright (c) PureSourceCode. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Models.UI
{
    /// <summary>
    /// Class BreadcrumbItem.
    /// </summary>
    public class BreadcrumbItem
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label { get; set; }
    }
}