using DummyAPI.Middlewares;
using DummyAPI.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Prometheus;
using Prometheus.Advanced;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace DummyAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<BloggingContext>(options => options.UseSqlite("Data source=..\\dummy.db"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("dummy", new Info { Title = "Dummy API" });
            });

            services.AddSingleton<ICollectorRegistry>(DefaultCollectorRegistry.Instance);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use((ctx, x) =>
            {
                Console.WriteLine(ctx.Request.Path);
                return x.Invoke();
            });

            app.UseMetricServer();
            app.UseMiddleware<ResponseTimeMiddleware>();
            app.UseMiddleware<StatusCodeMiddleware>();

            app.UseCors(builder => {
                builder.AllowAnyOrigin();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/dummy/swagger.json", "Dummy API");
            });


            app.UseMvc();
        }
    }
}
