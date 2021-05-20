// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using FluentValidation;

namespace Wolf.ManagerService.Application.Commands.Application.ChangeState
{
    /// <summary>
    /// 更改状态校验
    /// </summary>
    public class ChangeStateCommandValidator : AbstractValidator<ChangeStateCommand>
    {
        /// <summary>
        ///
        /// </summary>
        public ChangeStateCommandValidator()
        {
            RuleFor(x => x.Id).Must(x => x != default(Guid)).WithMessage("请选择应用");
        }
    }
}
