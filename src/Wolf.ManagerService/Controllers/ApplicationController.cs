// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wolf.Infrastructure.Core.Configurations.Response;
using Wolf.Infrastructure.Core.Request;
using Wolf.ManagerService.Application.Commands.Application;

namespace Wolf.ManagerService.Controllers
{
    /// <summary>
    /// 应用配置
    /// </summary>
    public class ApplicationController : BaseController
    {
        private readonly IMediator _mediator;

        /// <summary>
        ///
        /// </summary>
        /// <param name="mediator"></param>
        public ApplicationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        #region 添加应用

        /// <summary>
        /// 添加应用
        /// </summary>
        /// <param name="command"></param>
        /// <param name="baseUserRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] AddApplicationCommand command, BaseUserRequest baseUserRequest)
        {
            command?.SetOperateUser(baseUserRequest);
            ApiResultResponse<string> apiResultResponse = await this._mediator.Send(command);
            return GetJson(apiResultResponse);
        }

        #endregion
    }
}
