// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Infrastructure.Core.Configurations.Request;

namespace Wolf.ManagerService.Application.Commands
{
    /// <summary>
    /// 基础用户信息
    /// </summary>
    public class BaseUserCommand
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public BaseUserRequest User { get; set; }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="user"></param>
        public void SetOperateUser(BaseUserRequest user)
        {
            this.User = user;
        }
    }
}
