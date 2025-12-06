using System;

namespace WebApplicationMVC
{
    public static class TrafficLoggerExtensions
    {
        public static IApplicationBuilder UseTrafficLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TrafficLoggerMiddleware>();
        }
    }
}