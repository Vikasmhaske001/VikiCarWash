using System.Net;
using System.Text.Json;

namespace VikiCarWash.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

        if (ex.Message.Contains("not found"))
            statusCode = HttpStatusCode.NotFound;

        var response = new
        {
            StatusCode = (int)statusCode,
            Message = ex.Message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}