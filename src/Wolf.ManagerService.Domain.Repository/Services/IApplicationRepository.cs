// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Wolf.DependencyInjection.Abstracts;
using Wolf.Extensions.DataBase.Abstractions;
using Wolf.ManagerService.Domain.AggregatesModel;

namespace Wolf.ManagerService.Domain.Repository.Services
{
    /// <summary>
    /// 应用
    /// </summary>
    public interface IApplicationRepository : IRepository<ManagerDbContext, Applications, Guid>,
        IPerRequest<ManagerDbContext, Applications, Guid>
    {
        /// <summary>
        /// 根据应用名称得到应用信息
        /// </summary>
        /// <param name="name">应用名称</param>
        /// <returns></returns>
        Task<Applications> GetAsync(string name);

        /// <summary>
        /// 根据应用名称判断是否存在
        /// </summary>
        /// <param name="name">应用名称</param>
        /// <returns></returns>
        Task<bool> ExistAsync(string name);
    }
}
