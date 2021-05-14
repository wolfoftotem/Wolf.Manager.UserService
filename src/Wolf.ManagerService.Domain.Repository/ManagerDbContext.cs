// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;
using Wolf.Extensions.DataBase.MySql;

namespace Wolf.ManagerService.Domain.Repository
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class ManagerDbContext : MySqlDbContext<ManagerDbContext>
    {
        public ManagerDbContext(DbContextOptions<ManagerDbContext> options)
            : base(options)
        {
        }
    }
}
