// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;

namespace Wolf.ManagerService.Infrastructure
{
    /// <summary>
    ///
    /// </summary>
    public static class StartUp
    {
        #region 启动

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection Run(IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }

        #endregion
    }
}
