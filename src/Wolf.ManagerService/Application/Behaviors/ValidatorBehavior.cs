// Copyright (c) zhenlei520 All rights reserved.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Wolf.Systems.Exception;

namespace Wolf.ManagerService.Application.Behaviors
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(IValidator<TRequest>[] validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators.Select(v => v.Validate(request)).FirstOrDefault(x => x.Errors.Count > 0);

            if (failures != null)
            {
                throw new BusinessException($"{failures.Errors.Select(x => x.ErrorMessage).FirstOrDefault()}");
            }

            return await next();
        }
    }
}
