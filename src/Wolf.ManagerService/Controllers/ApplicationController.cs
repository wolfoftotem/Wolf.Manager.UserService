// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wolf.Extensions.DataBase.Abstractions;
using Wolf.Infrastructure.Core.Configurations.Response;
using Wolf.Infrastructure.Core.Request;
using Wolf.ManagerService.Application.Commands.Application.AddApplication;
using Wolf.ManagerService.Application.Commands.Application.ChangeState;
using Wolf.ManagerService.Application.Commands.Application.EditApplication;
using Wolf.ManagerService.Domain.AggregatesModel;
using Wolf.ManagerService.Domain.Repository;
using Wolf.ManagerService.Request.Application.List;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Core;

namespace Wolf.ManagerService.Controllers
{
    /// <summary>
    /// 应用配置
    /// </summary>
    public class ApplicationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IQuery<ManagerDbContext, Applications, Guid> _applicationQuery;

        /// <summary>
        ///
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="applicationQuery"></param>
        public ApplicationController(IMediator mediator, IQuery<ManagerDbContext, Applications, Guid> applicationQuery)
        {
            this._mediator = mediator;
            this._applicationQuery = applicationQuery;
        }

        #region 添加应用

        /// <summary>
        /// 添加应用
        /// </summary>
        /// <param name="command"></param>
        /// <param name="baseUserRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddAsync([FromBody] AddApplicationCommand command, BaseUserRequest baseUserRequest)
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
        public async Task<JsonResult> EditAsync([FromBody] EditApplicationCommand command, BaseUserRequest baseUserRequest)
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
        public async Task<JsonResult> ChangeStateAsync([FromBody] ChangeStateCommand command,
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
        public async Task<JsonResult> GetListAsync(RequestListQuery query, BaseUserRequest baseUserRequest)
        {
            Expression<Func<Applications, bool>> condition = x => true;
            if (!query.Name.IsNullOrWhiteSpace())
            {
                condition = condition.And(x => x.Name.Contains(query.Name));
            }

            var data = await this._applicationQuery.GetQueryable().Where(condition).Select(x => new ResponseListDto()
            {
                Id = x.Id,
                Name = x.Name,
                Summary = x.Summary,
                State = x.State,
                UpdateTime = x.UpdateTime
            }).ListPagerAsync(query.PageSize, query.PageIndex, true);
            return GetJson(new ApiResultResponse<IPage<ResponseListDto>>(200, data, "success"));
        }

        #endregion
    }
}
