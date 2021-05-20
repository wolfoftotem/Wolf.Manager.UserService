// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using MediatR;
using Newtonsoft.Json;
using Wolf.Infrastructure.Core.Configurations.Response;

namespace Wolf.ManagerService.Application.Commands.Application.EditApplication
{
    /// <summary>
    /// 编辑应用
    /// </summary>
    public class EditApplicationCommand : BaseUserCommand, IRequest<ApiResultResponse<string>>
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
    }
}
