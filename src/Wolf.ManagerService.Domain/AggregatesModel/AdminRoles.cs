// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Infrastructure.Core.Extensions.Common;
using Wolf.Systems.Data.Entities;

namespace Wolf.ManagerService.Domain.AggregatesModel
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class AdminRoles : AggregateRoot<Guid>
    {
        /// <summary>
        ///
        /// </summary>
        public AdminRoles()
        {
            base.Id = ToolsCommon.GetGuid();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="appid">应用id</param>
        /// <param name="userId">用户id</param>
        /// <param name="roleId">角色id</param>
        public AdminRoles(Guid appid,Guid userId, Guid roleId) : this()
        {
            this.Appid = appid;
            this.UserId = userId;
            this.RoleId = roleId;
        }

        /// <summary>
        /// 应用id
        /// </summary>
        public Guid Appid { get; private set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
