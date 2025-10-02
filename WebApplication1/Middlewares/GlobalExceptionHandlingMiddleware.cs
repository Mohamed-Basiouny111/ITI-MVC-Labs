using System.Diagnostics;

namespace WebApplication1.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        RequestDelegate _next;
        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Req Method => {context.Request.Method} , Req URL => {context.Request.Path}");
            await _next(context);
            stopwatch.Stop();
            Console.WriteLine($"Resp => {context.Response.StatusCode} , Req Time => {stopwatch.ElapsedMilliseconds} ms");
        }
    }
   
    public static class UseLoggingMiddleware
    {
        public static IApplicationBuilder UseLoggingMiddlewareCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        }
    }

}
