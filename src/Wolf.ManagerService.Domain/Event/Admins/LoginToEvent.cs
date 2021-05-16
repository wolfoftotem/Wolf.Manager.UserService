// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using MediatR;

namespace Wolf.ManagerService.Domain.Event.Admins
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginToEvent : INotification
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="ip">用户访问ip</param>
        /// <param name="userAgent">用户UserAgent</param>
        /// <param name="appid">应用id</param>
        public LoginToEvent(Guid userId, string ip, string userAgent, Guid appid)
        {
            UserId = userId;
            Ip = ip;
            UserAgent = userAgent;
            Appid = appid;
        }

        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// 用户访问ip
        /// </summary>
        public string Ip { get; }

        /// <summary>
        /// 用户UserAgent
        /// </summary>
        public string UserAgent { get; }

        /// <summary>
        /// 应用id
        /// </summary>
        public Guid Appid { get; }
    }
}
