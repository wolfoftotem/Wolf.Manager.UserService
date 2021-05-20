// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using MediatR;
using Wolf.Infrastructure.Core.Configurations.Response;

namespace Wolf.ManagerService.Application.Commands.Application.ChangeState
{
    /// <summary>
    /// 更改状态
    /// </summary>
    public class ChangeStateCommand: BaseUserCommand, IRequest<ApiResultResponse<string>>
    {
        /// <summary>
        ///
        /// </summary>
        public ChangeStateCommand()
        {

        }

        /// <summary>
        /// 应用id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 应用状态
        /// </summary>
        public bool State { get; set; }
    }
}
