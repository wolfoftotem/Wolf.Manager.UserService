// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Wolf.ManagerService.Response.System
{
    /// <summary>
    /// 系统平台信息
    /// </summary>
    public class SystemPlatformResponse
    {
        /// <summary>
        /// 运行环境信息
        /// </summary>
        [JsonProperty(PropertyName = "run")]
        public SystemRunEvnResponse Run { get; set; }

        /// <summary>
        /// 环境信息
        /// </summary>
        [JsonProperty(PropertyName = "platform")]
        public SystemPlatformInfoResponse Platform { get; set; }
    }
}
