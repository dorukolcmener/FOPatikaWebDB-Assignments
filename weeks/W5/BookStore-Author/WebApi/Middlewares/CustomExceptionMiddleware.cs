using System.Diagnostics;
using Newtonsoft.Json;
using WebApi.Services;

namespace WebApi.Middlewares;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerService _loggerService;
    public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
    {
        _next = next;
        _loggerService = loggerService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var watch = Stopwatch.StartNew();
        try
        {
            string message = $"Request {context.Request.Method} {context.Request.Path}";
            _loggerService.Write(message);

            await _next(context);
            watch.Stop();
            message = $"Response {context.Request.Method} - {context.Request.Path} responded {context.Response.StatusCode} in {watch.ElapsedMilliseconds} ms";
            _loggerService.Write(message);
        }
        catch (Exception ex)
        {
            watch.Stop();
            await HandleExceptionAsync(context, ex, watch);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex, Stopwatch watch)
    {
        string message = $"Error {context.Request.Method} - {context.Response.StatusCode} - Error Message {ex.Message} in {watch.ElapsedMilliseconds} ms";
        _loggerService.Write(message);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
        return context.Response.WriteAsync(result);
    }
}

public static class CustomExceptionMiddlewareExtension
{
    public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionMiddleware>();
    }
}