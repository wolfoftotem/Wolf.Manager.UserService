﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Extensions.AutomationConfiguration.Interface;

namespace Wolf.ManagerService.Domain.Configurations
{
    /// <summary>
    /// 配置
    /// </summary>
    public class AppConfig : ISingletonConfigModel
    {
        /// <summary>
        /// 配置 connection string
        /// </summary>
        public string DbConn { get; set; }

        /// <summary>
        /// enable mysql log
        /// </summary>
        public bool EnableDebug { get; set; }

        /// <summary>
        /// 是否启用定时任务
        /// </summary>
        public bool RunTask { get; set; }

        /// <summary>
        /// 是否迁移
        /// </summary>
        public bool Migrate { get; set; }
    }
}
