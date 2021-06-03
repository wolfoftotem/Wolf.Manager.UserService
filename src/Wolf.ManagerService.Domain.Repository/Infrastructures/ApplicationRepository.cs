// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wolf.Extensions.DataBase.MySql;
using Wolf.ManagerService.Domain.AggregatesModel;
using Wolf.ManagerService.Domain.Repository.Services;
using Wolf.Systems.Data.Abstractions;

namespace Wolf.ManagerService.Domain.Repository.Infrastructures
{
    /// <summary>
    ///
    /// </summary>
    public class ApplicationRepository : Repository<ManagerDbContext, Applications, Guid>, IApplicationRepository
    {
        public ApplicationRepository(IUnitOfWork<ManagerDbContext> unitOfWork) : base(unitOfWork)
        {
        }

        #region 根据应用名称得到应用信息

        /// <summary>
        /// 根据应用名称得到应用信息
        /// </summary>
        /// <param name="name">应用名称</param>
        /// <returns></returns>
        public Task<Applications> GetAsync(string name)
        {
            return Dbcontext.Set<Applications>().FirstOrDefaultAsync(x => x.Name == name);
        }

        #endregion

        #region 根据应用名称判断是否存在

        /// <summary>
        /// 根据应用名称判断是否存在
        /// </summary>
        /// <param name="name">应用名称</param>
        /// <returns></returns>
        public Task<bool> ExistAsync(string name)
        {
            return Dbcontext.Set<Applications>().AnyAsync(x => x.Name == name);
        }

        #endregion
    }
}
