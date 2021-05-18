// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wolf.Infrastructure.Core.Configurations.Response;
using Wolf.ManagerService.Domain.AggregatesModel;
using Wolf.ManagerService.Domain.Repository;
using Wolf.ManagerService.Domain.Repository.Services;
using Wolf.Systems.Data.Abstractions;

namespace Wolf.ManagerService.Application.Commands.Application
{
    /// <summary>
    ///
    /// </summary>
    public class AddApplicationCommandHandler : IRequestHandler<AddApplicationCommand, ApiResultResponse<string>>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork<ManagerDbContext> _unitOfWork;

        /// <summary>
        ///
        /// </summary>
        /// <param name="applicationRepository"></param>
        /// <param name="unitOfWork"></param>
        public AddApplicationCommandHandler(IApplicationRepository applicationRepository,IUnitOfWork<ManagerDbContext> unitOfWork)
        {
            this._applicationRepository = applicationRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ApiResultResponse<string>> Handle(AddApplicationCommand request,
            CancellationToken cancellationToken)
        {
            if (await this._applicationRepository.ExistAsync(request.Name))
            {
                return new ApiResultResponse<string>(201, null, "应用已存在");
            }

            await this._applicationRepository.AddAsync(new Applications(request.Name, request.Summary, request.User.UserId));
            // await this._unitOfWork.SaveChangesAsync(cancellationToken);
            return new ApiResultResponse<string>(200, string.Empty, "添加应用成功");
        }
    }
}
