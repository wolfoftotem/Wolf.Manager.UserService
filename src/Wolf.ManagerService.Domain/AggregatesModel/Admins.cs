// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Security.Claims;
using Wolf.Infrastructure.Core.Configurations.Enumeration;
using Wolf.Infrastructure.Core.Extensions.Common;
using Wolf.ManagerService.Domain.Event.Admins;
using Wolf.ManagerService.Domain.SeedWork;
using Wolf.ManagerService.Infrastructure.Configurations;
using Wolf.ManagerService.Infrastructure.Extensions;
using Wolf.Systems.Core;

namespace Wolf.ManagerService.Domain.AggregatesModel
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Admins : AggregateRootWork<Guid>
    {
        /// <summary>
        ///
        /// </summary>
        public Admins()
        {
            base.Id = ToolsCommon.GetGuid();
            this.PasswordSalt = ToolsCommon.RandomProvider.GenerateSpecifiedString(6, null);
            this.ForbitTime = null;
            this.UserState = UserState.Normal;
            this.RegisterTime = DateTimeOffset.Now;
            this.LastUpdateTime = DateTimeOffset.Now;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="account">账户信息</param>
        /// <param name="realName">真实姓名</param>
        /// <param name="password">密码</param>
        public Admins(string account, string realName, string password) : this()
        {
            this.Account = account;
            this.PasswordHash = (password + this.PasswordSalt).Sha256();
            this.RealName = realName;
        }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; private set; }

        /// <summary>
        /// 密码盐
        /// </summary>
        public string PasswordSalt { get; private set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public UserState UserState { get; private set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTimeOffset RegisterTime { get; private set; }

        /// <summary>
        /// 禁用时间
        /// </summary>
        public DateTimeOffset? ForbitTime { get; private set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTimeOffset LastUpdateTime { get; private set; }

        #region methods

        #region 登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="options">jwt配置信息</param>
        /// <param name="appid">应用id</param>
        /// <param name="ip">用户ip</param>
        /// <param name="userAgent">用户浏览器UserAgent</param>
        /// <returns></returns>
        public string Login(JwtOptions options, Guid appid, string ip, string userAgent)
        {
            this.LastUpdateTime = DateTimeOffset.Now;
            this.AddDomainEvent(new LoginToEvent(this.Id, ip, userAgent, appid));
            return JwtCommon.Instance.GetToken(new List<Claim>()
            {
                new Claim("UserId", this.Id.ToString()),
                new Claim("Account", this.Account.SafeString())
            }, options, appid);
        }

        #endregion

        #endregion
    }
}
