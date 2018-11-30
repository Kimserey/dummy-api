using Microsoft.AspNetCore.Http;
using Prometheus;
using Prometheus.Advanced;
using System;
using System.Threading.Tasks;

namespace DummyAPI.Monitoring
{
    public class StatusCodeMiddleware
    {
        private readonly RequestDelegate _next;

        public StatusCodeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMonitoringService service, ICollectorRegistry registry)
        {
            await _next(context);

            if (service.Monitor(context.Request.Method, context.Request.Path))
            {
                var counter =
                    Metrics
                        .WithCustomRegistry(registry)
                        .CreateCounter("api_status_code_count", "API Status Code count", "method", "path", "status_code");

                counter
                    .WithLabels(context.Request.Method, context.Request.Path, context.Response.StatusCode.ToString())
                    .Inc();
            }
        }
    }
}
