// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.ManagerService.Request.User
{
    /// <summary>
    /// 登录Request
    /// </summary>
    public class LoginRequest:IFluentlValidatorEntity
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 应用id
        /// </summary>
        public long Appid { get; set; }
    }
}
