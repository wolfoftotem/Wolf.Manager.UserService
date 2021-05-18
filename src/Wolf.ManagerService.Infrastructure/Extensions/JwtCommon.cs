// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Wolf.ManagerService.Infrastructure.Configurations;

namespace Wolf.ManagerService.Infrastructure.Extensions
{
    /// <summary>
    /// jwt帮助类
    /// </summary>
    public class JwtCommon
    {
        /// <summary>
        /// Jwt实例
        /// </summary>
        public static JwtCommon Instance = new JwtCommon();


        #region 得到授权Token

        /// <summary>
        /// 得到授权Token
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public string GetToken(IEnumerable<Claim> claims, JwtOptions options)
        {
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Secret));
            var jwtSecurityToken = new JwtSecurityToken(options.Issuer, options.Audience, claims, DateTime.Now,
                DateTime.Now.AddSeconds(options.Expires),
                new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        #endregion
    }
}
