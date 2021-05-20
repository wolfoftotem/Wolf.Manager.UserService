// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using MediatR;
using Newtonsoft.Json;
using Wolf.Infrastructure.Core.Configurations.Response;

namespace Wolf.ManagerService.Application.Commands.Application.AddApplication
{
    /// <summary>
    /// 添加应用
    /// </summary>
    public class AddApplicationCommand : BaseUserCommand, IRequest<ApiResultResponse<string>>
    {
        /// <summary>
        ///
        /// </summary>
        public AddApplicationCommand()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name">应用名称</param>
        /// <param name="summary">应用简介</param>
        public AddApplicationCommand(string name, string summary) : this()
        {
            Name = name;
            Summary = summary;
        }

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
    }
}
