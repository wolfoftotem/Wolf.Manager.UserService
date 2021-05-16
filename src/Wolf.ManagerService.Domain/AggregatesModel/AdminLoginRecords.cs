// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Infrastructure.Core.Extensions.Common;
using Wolf.ManagerService.Domain.SeedWork;

namespace Wolf.ManagerService.Domain.AggregatesModel
{
    /// <summary>
    /// 管理登录记录
    /// </summary>
    public class AdminLoginRecords : AggregateRootWork<Guid>
    {
        /// <summary>
        ///
        /// </summary>
        public AdminLoginRecords()
        {
            this.Id = ToolsCommon.GetGuid();
            this.CreateTime = DateTimeOffset.Now;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="ip">登录ip</param>
        /// <param name="userAgent">浏览器UserAgent</param>
        /// <param name="appid">应用id</param>
        public AdminLoginRecords(Guid userId, string ip, string userAgent,Guid appid) : this()
        {
            this.UserId = userId;
            this.Ip = ip;
            this.UserAgent = userAgent;
            this.Appid = appid;
        }

        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 应用id
        /// </summary>
        public Guid Appid { get; private set; }

        /// <summary>
        /// 登录ip
        /// </summary>
        public string Ip { get; private set; }

        /// <summary>
        /// 浏览器UserAgent
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeOffset CreateTime { get; private set; }
    }
}
