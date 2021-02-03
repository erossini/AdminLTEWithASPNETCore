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
// <copyright file="ClaimExtensions.cs" company="AdminLTEWithASPNETCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdminLTEWithASPNETCore.Extensions
{
    /// <summary>
    /// Class ClaimExtensions.
    /// </summary>
    public static class ClaimExtensions
    {
        /// <summary>
        /// Gets a claim from a list of claims
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="claimName"></param>
        /// <returns></returns>
        public static Claim GetClaim(this IEnumerable<Claim> claims, string claimName)
        {
            Claim rtn = null;

            if (!string.IsNullOrEmpty(claimName))
            {
                rtn = claims.FirstOrDefault(x => x.Type == claimName);
            }

            return rtn;
        }

        /// <summary>
        /// Gets the value of the requested claim if it exists
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="claimName"></param>
        /// <returns></returns>
        public static string GetClaimValue(this IEnumerable<Claim> claims, string claimName)
        {
            string rtn = null;

            if (!string.IsNullOrEmpty(claimName))
            {
                Claim claim = GetClaim(claims, claimName);
                if (claim != null)
                    rtn = claim.Value;
            }

            return rtn;
        }

        /// <summary>
        /// Updates a claim with a new value
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="claimName"></param>
        /// <param name="newValue"></param>
        public static void UpdateClaim(this List<Claim> claims, string claimName, string newValue)
        {
            Claim claim = claims.GetClaim(claimName);
            if (claim != null)
                claims.Remove(claim);

            claims.Add(new Claim(claimName, newValue));
        }
    }
}
