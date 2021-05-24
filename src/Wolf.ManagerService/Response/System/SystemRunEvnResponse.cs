// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Newtonsoft.Json;
using Wolf.Systems.Core.Common.Systems;

namespace Wolf.ManagerService.Response.System
{
    /// <summary>
    /// 系统运行环境
    /// </summary>
    public class SystemRunEvnResponse
    {
        /// <summary>
        ///
        /// </summary>
        public SystemRunEvnResponse()
        {
            var proc = Process.GetCurrentProcess();
            var mem = proc.WorkingSet64;
            var cpu = proc.TotalProcessorTime;
            this.UsedMem = mem / 1024.0;
            this.UsedCPUTime = cpu.TotalMilliseconds;
        }

        /// <summary>
        /// 机器名称
        /// </summary>
        [JsonProperty(PropertyName = "machine_name")]
        public string MachineName => Environment.MachineName;

        /// <summary>
        /// 用户网络域名
        /// </summary>
        [JsonProperty(PropertyName = "user_domain_name")]
        public string UserDomainName => Environment.UserDomainName;

        /// <summary>
        /// 分区磁盘
        /// </summary>
        [JsonProperty(PropertyName = "get_logical_drives")]
        public string GetLogicalDrives => string.Join(", ", Environment.GetLogicalDrives());

        /// <summary>
        /// 系统目录
        /// </summary>
        [JsonProperty(PropertyName = "system_directory")]
        public string SystemDirectory => Environment.SystemDirectory;

        /// <summary>
        /// 系统已运行时间(毫秒)
        /// </summary>
        [JsonProperty(PropertyName = "tick_count")]
        public int TickCount => Environment.TickCount;

        /// <summary>
        /// 是否在交互模式中运行
        /// </summary>
        [JsonProperty(PropertyName = "user_interactive")]
        public bool UserInteractive => Environment.UserInteractive;

        /// <summary>
        /// 当前关联用户名
        /// </summary>
        [JsonProperty(PropertyName = "user_name")]
        public string UserName => Environment.UserName;

        /// <summary>
        /// Web程序核心框架版本
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version => Environment.Version.ToString();

        /// <summary>
        /// 磁盘分区
        /// </summary>
        [JsonProperty(PropertyName = "system_drive")]
        public string SystemDrive => EnvironmentCommon.GetOs.IsWindows()
            ? ""
            : Environment.ExpandEnvironmentVariables("%SystemDrive%");

        /// <summary>
        /// 进程已使用物理内存(kb)
        /// </summary>
        [JsonProperty(PropertyName = "used_mem")]
        public double UsedMem { get; }

        /// <summary>
        /// 进程已占耗CPU时间(ms)
        /// </summary>
        [JsonProperty(PropertyName = "used_cpu_time")]
        public double UsedCPUTime { get; }

        //对Linux无效
        /// <summary>
        /// 系统目录
        /// </summary>
        [JsonProperty(PropertyName = "system_root")]
        public string SystemRoot => EnvironmentCommon.GetOs.IsWindows()
            ? ""
            : Environment.ExpandEnvironmentVariables("%SystemRoot%");
    }
}
