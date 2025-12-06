using System;

namespace WebApplicationMVC
{
    public class TrafficLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TrafficLoggerMiddleware> _logger;

        public TrafficLoggerMiddleware(RequestDelegate next, ILogger<TrafficLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Incoming Request: {Method} - {Path}",
                context.Request.Method, context.Request.Path);
            _logger.LogInformation("---- BEFORE AUTHENTICATION ----");
            _logger.LogInformation("IsAuthenticated: {auth}", context.User.Identity?.IsAuthenticated);
            _logger.LogInformation("UserName: {name}", context.User.Identity?.Name);

            await _next(context);

            _logger.LogInformation("Outgoing Response: {StatusCode}",
                context.Response.StatusCode);
            _logger.LogInformation("---- AFTER AUTHORIZATION ----");
            _logger.LogInformation("IsAuthenticated: {auth}", context.User.Identity?.IsAuthenticated);
            _logger.LogInformation("UserName: {name}", context.User.Identity?.Name);
        }
    }
}
