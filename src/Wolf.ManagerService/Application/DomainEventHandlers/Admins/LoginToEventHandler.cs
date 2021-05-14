// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wolf.Extensions.DataBase.Abstractions;
using Wolf.ManagerService.Domain.AggregatesModel;
using Wolf.ManagerService.Domain.Event.Admins;
using Wolf.ManagerService.Domain.Repository;

namespace Wolf.ManagerService.Application.DomainEventHandlers.Admins
{
    /// <summary>
    ///
    /// </summary>
    public class LoginToEventHandler : INotificationHandler<LoginToEvent>
    {
        private readonly IRepository<ManagerDbContext, AdminLoginRecords, Guid> _repository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="repository"></param>
        public LoginToEventHandler(IRepository<ManagerDbContext, AdminLoginRecords, Guid> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(LoginToEvent notification, CancellationToken cancellationToken)
        {
            return this._repository.AddAsync(new AdminLoginRecords(notification.UserId, notification.Ip,
                notification.UserAgent,
                notification.Appid));
        }
    }
}
