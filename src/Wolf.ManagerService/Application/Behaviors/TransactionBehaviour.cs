using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wolf.ManagerService.Domain.Repository;
using Wolf.ManagerService.Extensions;
using Wolf.Systems.Data.Abstractions;

namespace Wolf.ManagerService.Application.Behaviors
{
    /// <summary>
    /// 交易
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region 构造函数

        private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;
        private readonly DbContext _dbContext;

        public TransactionBehaviour(IUnitOfWork<ManagerDbContext> dbContext,
            ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
        {
            _dbContext = dbContext as DbContext ?? throw new ArgumentException(nameof(ManagerDbContext));
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        }

        #endregion

        /// <summary>
        /// 交易处理
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken">事务标识</param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            //类名
            var typeName = request.GetGenericTypeName();
            TResponse response = default(TResponse);
            try
            {
                //如果开启事务
                // if (_dbContext.HasActiveTransaction)
                // {
                //     return await next();
                // }
                // else
                // {
                var strategy = _dbContext.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    // using (var transaction = await _dbContext.BeginTransactionAsync(cancellationToken))
                    // {
                    response = await next();
                    await this._dbContext.SaveChangesAsync(cancellationToken);
                    // await _dbContext.CommitTransactionAsync(transaction);
                    // }
                });
                return response;
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
