// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using FluentValidation;
using Wolf.DependencyInjection.Abstracts;
using Wolf.Infrastructure.Core.Extensions.Validation;
using Wolf.Systems.Core;

namespace Wolf.ManagerService.Request.User
{
    /// <summary>
    /// 登录Request
    /// </summary>
    public class LoginRequest : IFluentlValidatorEntity
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 应用id
        /// </summary>
        public Guid Appid { get; set; }

        /// <summary>
        ///
        /// </summary>
        public class LoginRequestValidator : AbstractValidator<LoginRequest>, IFluentlValidator<LoginRequest>,
            IPerRequest
        {
            /// <summary>
            ///
            /// </summary>
            public LoginRequestValidator()
            {
                RuleFor(x => x.Account).Must(x => !x.IsNullOrWhiteSpace()).WithMessage("账号不能为空").MaximumLength(30)
                    .WithMessage("账号长度过长");
                RuleFor(x => x.Password).Must(x => !x.IsNullOrWhiteSpace()).WithMessage("密码不能为空").MaximumLength(20)
                    .WithMessage("密码长度过长");
                RuleFor(x => x.Appid).Must(x => !x.IsGuid()).WithMessage("不支持的应用");
            }
        }
    }
}
