// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Infrastructure.Core.Extensions.Common;
using Wolf.Systems.Data.Entities;

namespace Wolf.ManagerService.Domain.AggregatesModel
{
    /// <summary>
    /// 应用
    /// </summary>
    public class Applications : AggregateRoot<Guid>
    {
        /// <summary>
        ///
        /// </summary>
        public Applications()
        {
            this.Id = ToolsCommon.GetGuid();
            this.State = true;
            this.CreateTime = DateTimeOffset.Now;
            this.UpdateTime = DateTimeOffset.Now;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">应用名称</param>
        /// <param name="summary">简介</param>
        /// <param name="userId">用户id</param>
        public Applications(string name, string summary, Guid userId):this()
        {
            this.Name = name;
            this.Summary = summary;
            this.AddUserId = userId;
            this.EditUserId = userId;
        }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; private set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeOffset CreateTime { get; private set; }

        /// <summary>
        /// 添加用户id
        /// </summary>
        public Guid AddUserId { get; private set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTimeOffset UpdateTime { get; private set; }

        /// <summary>
        /// 修改用户id
        /// </summary>
        public Guid EditUserId { get; private set; }
    }
}
