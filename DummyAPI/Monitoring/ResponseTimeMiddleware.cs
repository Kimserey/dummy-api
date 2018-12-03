using Microsoft.AspNetCore.Http;
using Prometheus;
using Prometheus.Advanced;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DummyAPI.Monitoring
{
    public class ResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMonitoringService service, ICollectorRegistry registry)
        {
            if (service.Monitor(context.Request.Method, context.Request.Path))
            {
                var sw = Stopwatch.StartNew();
                await _next(context);
                sw.Stop();

                var histogram =
                    Metrics
                        .WithCustomRegistry(registry)
                        .CreateHistogram(
                            "api_response_time_seconds",
                            "API Response Time in seconds",
                            null,
                            "method",
                            "path");

                histogram
                    .WithLabels(context.Request.Method, context.Request.Path)
                    .Observe(sw.Elapsed.TotalSeconds);
            }
            else
            {
                await _next(context);
            }
        }
    }
}