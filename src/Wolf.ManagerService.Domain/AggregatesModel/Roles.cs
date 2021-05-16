// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Infrastructure.Core.Extensions.Common;
using Wolf.Systems.Data.Entities;

namespace Wolf.ManagerService.Domain.AggregatesModel
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Roles : AggregateRoot<Guid>
    {
        /// <summary>
        ///
        /// </summary>
        public Roles()
        {
            base.Id = ToolsCommon.GetGuid();
            this.State = true;
            this.CreateTime = DateTimeOffset.Now;
            this.UpdateTime = DateTimeOffset.Now;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="appid">应用id</param>
        /// <param name="name">角色名称</param>
        /// <param name="summary">角色简介</param>
        /// <param name="userId">用户id</param>
        public Roles(Guid appid, string name, string summary, Guid userId) : this()
        {
            this.Appid = appid;
            this.Name = name;
            this.Summary = summary;
            this.CreateUserId = userId;
            this.UpdateUserId = userId;
        }

        /// <summary>
        /// 应用id
        /// </summary>
        public Guid Appid { get; private set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeOffset CreateTime { get; private set; }

        /// <summary>
        /// 创建用户id
        /// </summary>
        public Guid CreateUserId { get; private set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTimeOffset UpdateTime { get; private set; }

        /// <summary>
        /// 修改用户id
        /// </summary>
        public Guid UpdateUserId { get; private set; }
    }
}
