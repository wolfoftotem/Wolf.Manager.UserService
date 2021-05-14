// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Extensions.AutomationConfiguration.Interface;

namespace Wolf.ManagerService.Infrastructure.Configurations
{
    /// <summary>
    ///
    /// </summary>
    public class JwtOptions : ISingletonConfigModel
    {
        /// <summary>
        /// 发行人
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// 秘钥
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 有效时间 单位：s
        /// </summary>
        public long Expires { get; set; }
    }
}
