// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wolf.Infrastructure.Core.Configurations.Response;
using Wolf.Infrastructure.Core.Request;
using Wolf.ManagerService.Application.Commands.Application;
using Wolf.ManagerService.Application.Commands.Application.AddApplication;
using Wolf.ManagerService.Application.Commands.Application.ChangeState;
using Wolf.ManagerService.Application.Commands.Application.EditApplication;
using Wolf.ManagerService.Request.Application.List;
using Wolf.Systems.Core.Configuration;

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

        #region 编辑应用

        /// <summary>
        /// 编辑应用
        /// </summary>
        /// <param name="command"></param>
        /// <param name="baseUserRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Edit([FromBody] EditApplicationCommand command, BaseUserRequest baseUserRequest)
        {
            command?.SetOperateUser(baseUserRequest);
            ApiResultResponse<string> apiResultResponse = await this._mediator.Send(command);
            return GetJson(apiResultResponse);
        }

        #endregion

        #region 更改状态

        /// <summary>
        /// 更改状态
        /// </summary>
        /// <param name="command"></param>
        /// <param name="baseUserRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ChangeState([FromBody] ChangeStateCommand command,
            BaseUserRequest baseUserRequest)
        {
            command?.SetOperateUser(baseUserRequest);
            ApiResultResponse<string> apiResultResponse = await this._mediator.Send(command);
            return GetJson(apiResultResponse);
        }

        #endregion

        #region 得到应用列表

        /// <summary>
        /// 得到应用列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="baseUserRequest"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetList(RequestListQuery query, BaseUserRequest baseUserRequest)
        {
            var list = new Page<ResponseListDto>();
            return GetJson(new ApiResultResponse<Page<ResponseListDto>>(200, list, "success"));
        }

        #endregion
    }
}
