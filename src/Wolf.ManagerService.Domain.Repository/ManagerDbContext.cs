// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Wolf.Extensions.DataBase.MySql;
using Wolf.ManagerService.Domain.Configurations;

namespace Wolf.ManagerService.Domain.Repository
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class ManagerDbContext : MySqlDbContext<ManagerDbContext>
    {
        private readonly AppConfig _appConfig;

        /// <summary>
        ///
        /// </summary>
        /// <param name="appConfig"></param>
        public ManagerDbContext(AppConfig appConfig)
        {
            this._appConfig = appConfig;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(this._appConfig.DbConn);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
