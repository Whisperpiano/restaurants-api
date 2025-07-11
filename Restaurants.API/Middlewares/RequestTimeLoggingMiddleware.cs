﻿using System.Diagnostics;

namespace Restaurants.API.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next.Invoke(context);
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds > 4000)
        {
            logger.LogInformation($"Request took [{context.Request.Method}] at {context.Request.Method} took {stopwatch.ElapsedMilliseconds} ms");       
        }
    }
}