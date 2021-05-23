// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Infrastructure.Core.Request;

namespace Wolf.ManagerService.Request.Application.List
{
    /// <summary>
    /// 请求列表条件
    /// </summary>
    public class RequestListQuery : BasePageQuery
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }
    }
}
