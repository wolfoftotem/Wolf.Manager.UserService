// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wolf.Infrastructure.Core.Configurations.Response;
using Wolf.ManagerService.Request.User;

namespace Wolf.ManagerService.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserController : BaseController
    {
        public UserController()
        {
        }

        #region 登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ApiResultResponse<string>> Login([FromBody] LoginRequest request)
        {

        }

        #endregion
    }
}
