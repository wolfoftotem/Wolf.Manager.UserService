// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Wolf.Systems.Core;

namespace Wolf.ManagerService.Infrastructure.Extensions
{
    /// <summary>
    ///
    /// </summary>
    public static class HttpCommon
    {
        #region 得到客户端ip

        private static readonly Regex Pv4Regex = new Regex(@"\b([0-9]{1,3}\.){3}[0-9]{1,3}$",
            RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        /// <summary>
        /// 得到客户端ip
        /// </summary>
        /// <param name="httpContext">请求上下文</param>
        /// <returns></returns>
        public static string GetClientIp(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return "0.0.0.0";
            }

            var ip = httpContext.Request.Headers["REMOTE_ADDR"].FirstOrDefault(); // could be a proxy -- beware
            var ipForwarded = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ipForwarded)) ipForwarded = httpContext.Connection.RemoteIpAddress.ToString();
            ipForwarded = Pv4Regex.Match(ipForwarded).Value;
            if (!string.IsNullOrEmpty(ipForwarded))
                ip = ipForwarded;

            return !string.IsNullOrEmpty(ip) ? ip : "0.0.0.0";
        }

        #endregion

        #region 得到客户端UserAgent

        /// <summary>
        /// 得到客户端UserAgent
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetClientUserAgent(this HttpContext httpContext)
        {
            return httpContext.Request.Headers["User-Agent"].SafeString();
        }

        #endregion
    }
}
