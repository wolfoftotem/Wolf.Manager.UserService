// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wolf.ManagerService.Domain.AggregatesModel;
using Wolf.ManagerService.Domain.Repository;
using Wolf.Systems.Core;

namespace Wolf.ManagerService.Extensions
{
    /// <summary>
    ///
    /// </summary>
    public static class IWebHostExtensions
    {
        /// <summary>
        /// 注册数据库迁移
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public static IHost MigrateDbContext(this IHost host)
        {
            return host.MigrateDbContext<ManagerDbContext>((context, serviceProvider) =>
            {
                Admins admins = context.Set<Admins>().FirstOrDefault(x => x.Account == "admin");
                if (admins == null)
                {
                    admins = new Admins("admin", "超级管理员", "lei123456");
                    context.Set<Admins>().Add(admins);
                }

                Applications applications = context.Set<Applications>().FirstOrDefault(x => x.Name == "系统配置");
                if (applications == null)
                {
                    applications = new Applications("系统配置", "配置后台权限", admins.Id);
                    context.Set<Applications>().Add(applications);
                }

                Roles roles = context.Set<Roles>().FirstOrDefault(x => x.Appid == applications.Id);
                if (roles == null)
                {
                    roles = new Roles(applications.Id, "超级管理员", "超级管理员", admins.Id);
                    context.Set<Roles>().Add(roles);
                }

                AdminRoles adminRoles = context.Set<AdminRoles>()
                    .FirstOrDefault(x => x.Appid == applications.Id && x.RoleId == roles.Id);
                if (adminRoles == null)
                {
                    adminRoles = new AdminRoles(applications.Id, admins.Id, roles.Id);
                    context.Set<AdminRoles>().Add(adminRoles);
                }

                context.SaveChanges();
            });
        }

        #region 注册Manager数据库链接

        /// <summary>
        /// 注册Manager数据库链接
        /// </summary>
        /// <param name="host"></param>
        /// <param name="seeder"></param>
        /// <returns></returns>
        public static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
            where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                if (serviceProvider.GetService<IConfiguration>().GetSection("AppConfig")["Migrate"]
                    .ConvertToBool(false))
                {
                    var context = serviceProvider.GetService<TContext>();
                    seeder.Invoke(context, serviceProvider);
                }
            }

            return host;
        }

        #endregion
    }
}
