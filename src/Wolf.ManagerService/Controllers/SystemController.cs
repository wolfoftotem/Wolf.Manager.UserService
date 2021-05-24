// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wolf.ManagerService.Response.System;

namespace Wolf.ManagerService.Controllers
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SystemController : BaseController
    {
        #region 得到系统环境

        /// <summary>
        /// 得到系统环境
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetEnvironmentAsync()
        {
            return await Task.FromResult(Success(new SystemPlatformResponse()
            {
                Run = new SystemRunEvnResponse(),
                Platform = new SystemPlatformInfoResponse()
            }));
        }

        #endregion
    }
}
