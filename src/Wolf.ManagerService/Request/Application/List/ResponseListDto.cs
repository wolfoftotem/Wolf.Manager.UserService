// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Newtonsoft.Json;

namespace Wolf.ManagerService.Request.Application.List
{
    /// <summary>
    /// 响应列表
    /// </summary>
    public class ResponseListDto
    {
        /// <summary>
        /// 应用id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 应用简介
        /// </summary>
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 应用状态
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public bool State { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonProperty(PropertyName = "update_time")]
        public DateTimeOffset UpdateTime { get; set; }
    }
}
