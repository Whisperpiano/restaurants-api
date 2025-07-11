using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException e)
        {
            logger.LogWarning(e, $"Not found exception: {e.Message}");
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Not found");       
        }
        catch (Exception e)
        {
            logger.LogError(e, $"Unhandled exception: {e.Message}");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}