// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wolf.Infrastructure.Core.Configurations.Response;
using Wolf.ManagerService.Domain.Repository.Services;
using Wolf.Systems.Exception;

namespace Wolf.ManagerService.Application.Commands.Application.EditApplication
{
    /// <summary>
    /// 编辑应用
    /// </summary>
    public class EditApplicationCommandHandler : IRequestHandler<EditApplicationCommand, ApiResultResponse<string>>
    {
        private readonly IApplicationRepository _applicationRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationRepository"></param>
        public EditApplicationCommandHandler(IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ApiResultResponse<string>> Handle(EditApplicationCommand request,
            CancellationToken cancellationToken)
        {
            var application = await this._applicationRepository.FindByIdAsync(request.Id);
            if (application != null)
            {
                application.Update(request.Name, request.Summary, request.User.UserId);
            }
            else
            {
                throw new BusinessException("应用不存在");
            }

            return new ApiResultResponse<string>(200, string.Empty, "编辑应用成功");
        }
    }
}
