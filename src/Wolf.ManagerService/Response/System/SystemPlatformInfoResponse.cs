// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Wolf.ManagerService.Response.System
{
    /// <summary>
    /// 系统运行平台
    /// </summary>
    public class SystemPlatformInfoResponse
    {
        /// <summary>
        /// 运行版本
        /// </summary>
        [JsonProperty(PropertyName = "framework_description")]
        public string FrameworkDescription => RuntimeInformation.FrameworkDescription;

        /// <summary>
        /// 操作系统
        /// </summary>
        [JsonProperty(PropertyName = "os_description")]
        public string OSDescription => RuntimeInformation.OSDescription;

        /// <summary>
        /// 操作系统版本
        /// </summary>
        [JsonProperty(PropertyName = "os_version")]
        public string OSVersion => Environment.OSVersion.ToString();

        /// <summary>
        /// 平台架构
        /// </summary>
        [JsonProperty(PropertyName = "os_architecture")]
        public string OSArchitecture => RuntimeInformation.OSArchitecture.ToString();
    }
}
