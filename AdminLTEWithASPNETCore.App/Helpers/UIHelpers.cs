// ***********************************************************************
// Assembly         : AdminLTEWithASPNETCore
// Author           : enric
// Blog             : 
// Blog URL         : 
// Created          : 02-03-2021
//
// Last Modified By : enric
// Last Modified On : 02-03-2021
// ***********************************************************************
// <copyright file="UIHelpers.cs" company="AdminLTEWithASPNETCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AdminLTEWithASPNETCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Helpers
{
    /// <summary>
    /// Class UIHelpers.
    /// </summary>
    public class UIHelpers
    {
        /// <summary>
        /// Gets the real name for the current user from Active Directory
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        public static string GetRealName(IEnumerable<System.Security.Claims.Claim> claims)
        {
            string rtn = string.Empty;

            if (claims != null)
            {
                rtn = claims.ToList().GetClaimValue("name");
                if (string.IsNullOrEmpty(rtn))
                    rtn = claims.ToList().GetClaimValue("email");
            }

            return rtn;
        }
    }
}
