// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wolf.Extensions.DataBase.Abstractions;
using Wolf.Infrastructure.Core.Request;
using Wolf.ManagerService.Domain.AggregatesModel;
using Wolf.ManagerService.Domain.Repository;
using Wolf.ManagerService.Infrastructure.Configurations;
using Wolf.ManagerService.Infrastructure.Extensions;
using Wolf.ManagerService.Request.User;
using Wolf.ManagerService.Response.User;
using Wolf.Systems.Core;

namespace Wolf.ManagerService.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IQuery<ManagerDbContext, Admins, Guid> _adminGuidQuery;
        private readonly IQuery<ManagerDbContext, Applications, Guid> _applicationQuery;
        private readonly IQuery<ManagerDbContext, AdminRoles, Guid> _adminRoleQuery;
        private readonly JwtOptions _jwtOptions;

        /// <summary>
        ///
        /// </summary>
        /// <param name="adminGuidQuery"></param>
        /// <param name="applicationQuery"></param>
        /// <param name="adminRoleQuery"></param>
        /// <param name="jwtOptions"></param>
        public UserController(IQuery<ManagerDbContext, Admins, Guid> adminGuidQuery,
            IQuery<ManagerDbContext, Applications, Guid> applicationQuery,
            IQuery<ManagerDbContext, AdminRoles, Guid> adminRoleQuery, JwtOptions jwtOptions)
        {
            this._adminGuidQuery = adminGuidQuery;
            this._applicationQuery = applicationQuery;
            this._adminRoleQuery = adminRoleQuery;
            this._jwtOptions = jwtOptions;
        }

        #region 登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> LoginAsync([FromBody] LoginRequest request)
        {
            if (!await this._applicationQuery.ExistsAsync(x => x.Id == request.Appid && x.State))
            {
                return Error("不支持的应用");
            }

            var login = await this._adminGuidQuery.GetOneAsync(x => x.Account == request.Account);
            if (login == null)
            {
                return Error("账号不存在");
            }

            if (login.PasswordHash != (request.Password + login.PasswordSalt).Sha256())
            {
                return Error("密码输入错误，请重新输入");
            }

            if (!await this._adminRoleQuery.ExistsAsync(x => x.UserId == login.Id && x.Appid == request.Appid))
            {
                return Error("权限不足");
            }

            return Success(new UserDetailResponse
            {
                Id = login.Id,
                Account = login.Account,
                RealName = login.RealName,
                UserState = login.UserState,
                RegisterTime = login.RegisterTime,
                LastUpdateTime = login.LastUpdateTime
            });
            return Success(login.Login(this._jwtOptions, request.Appid, HttpContext.GetClientIp(),
                HttpContext.GetClientUserAgent()));
        }

        #endregion

        #region 得到用户详情

        /// <summary>
        /// 得到用户详情
        /// </summary>
        /// <param name="baseUserRequest"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetAsync(BaseUserRequest baseUserRequest)
        {
            var user = await this._adminGuidQuery.GetQueryable().Where(x => x.Id == baseUserRequest.UserId).Select(x =>
                new UserDetailResponse()
                {
                    Id = x.Id,
                    Account = x.Account,
                    RealName = x.RealName,
                    UserState = x.UserState,
                    RegisterTime = x.RegisterTime,
                    LastUpdateTime = x.LastUpdateTime
                }).FirstOrDefaultAsync();
            if (user == null)
            {
                return Error("账号不存在");
            }

            return Success(user);
        }

        #endregion
    }
}
