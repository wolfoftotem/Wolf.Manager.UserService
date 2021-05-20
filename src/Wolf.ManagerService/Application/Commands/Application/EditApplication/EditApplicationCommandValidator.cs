// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using FluentValidation;
using Wolf.Systems.Core;

namespace Wolf.ManagerService.Application.Commands.Application.EditApplication
{
    /// <summary>
    /// 编辑应用
    /// </summary>
    public class EditApplicationCommandValidator : AbstractValidator<EditApplicationCommand>
    {
        /// <summary>
        ///
        /// </summary>
        public EditApplicationCommandValidator()
        {
            RuleFor(x => x.Id).Must(x => x != default(Guid)).WithMessage("请选择编辑应用");
            RuleFor(x => x.Name).Must(x => !x.IsNullOrWhiteSpace()).WithMessage("应用名称不能为空").MaximumLength(20)
                .WithMessage("应用名称长度过长");
            RuleFor(x => x.Summary).MaximumLength(50).WithMessage("简介长度过长");
        }
    }
}
