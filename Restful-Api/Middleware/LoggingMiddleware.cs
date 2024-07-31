namespace Restful_Api.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        //Simple logging example
        Console.WriteLine($"Entered the action: {context.Request.Method} {context.Request.Path}");
        await _next(context);
    }
}