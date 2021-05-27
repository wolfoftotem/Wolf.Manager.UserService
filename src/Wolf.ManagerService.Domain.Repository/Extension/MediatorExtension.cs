// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wolf.ManagerService.Domain.SeedWork;

namespace Wolf.ManagerService.Domain.Repository.Extension
{
    /// <summary>
    ///
    /// </summary>
    public static class MediatorExtension
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="dbContext"></param>
        /// <typeparam name="T"></typeparam>
        public static async Task DispatchDomainEventsAsync<T>(this IMediator mediator, DbContext dbContext)
        {
            var domainEntities = dbContext.ChangeTracker
                .Entries<AggregateRootWork<T>>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => { entity.Entity.ClearDomainEvents(); });

            var tasks = domainEvents
                .Select(async domainEvent =>
                {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
