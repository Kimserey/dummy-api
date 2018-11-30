using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DummyAPI.Monitoring
{
    public static class MonitoringExtensions
    {
        public static IServiceCollection AddMonitoring(this IServiceCollection services)
        {
            return services.AddSingleton<IMonitoringService, MonitoringService>();
        }

        public static IApplicationBuilder UseMonitoring(this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<ResponseTimeMiddleware>()
                .UseMiddleware<StatusCodeMiddleware>();
        }
    }
}