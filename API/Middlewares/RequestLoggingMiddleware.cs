namespace API.Middlewares
{
    public class RequestLoggingMiddleware(RequestDelegate _next, ILogger<RequestLoggingMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Handling request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            _logger.LogInformation($"Finished request");
        }
    }
}
