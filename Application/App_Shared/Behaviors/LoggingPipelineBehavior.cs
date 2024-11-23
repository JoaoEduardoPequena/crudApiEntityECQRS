﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.App_Shared.Behaviors;
public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        //Request
        _logger.LogInformation(
            "Handling {Name}. {@Date}",
            requestName,
            DateTime.UtcNow);

        var result = await next();
        
        //Response
        _logger.LogInformation(
            "CleanArchitecture Request: {Name} {@request}. {@Date}",
            requestName,
            request,
            DateTime.UtcNow);

        return result;
    }
}
