// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Infrastructure.Core.Configurations.Enumeration;

namespace Wolf.ManagerService.Response.User
{
    /// <summary>
    /// 用户详情
    /// </summary>
    public class UserDetailResponse
    {
        /// <summary>
        /// 账户id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public UserState UserState { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTimeOffset RegisterTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTimeOffset LastUpdateTime { get; set; }
    }
}
