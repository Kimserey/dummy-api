namespace DummyAPI.FSharp

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Newtonsoft.Json.Serialization
open Newtonsoft.Json
open Microsoft.EntityFrameworkCore
open Persistence
open Swashbuckle.AspNetCore.Swagger

type Startup() =

    member this.ConfigureServices(services: IServiceCollection) =

        services
            .AddMvc()
            .AddJsonOptions(fun options ->
                options.SerializerSettings.ContractResolver <- CamelCasePropertyNamesContractResolver()
                options.SerializerSettings.ReferenceLoopHandling <- ReferenceLoopHandling.Ignore
            ) |> ignore

        services.AddDbContext<BloggingContext>(fun options ->
            options.UseSqlite("Data source=..\\dummy.db") |> ignore
        ) |> ignore


        services.AddSwaggerGen(fun c ->
            c.SwaggerDoc("dummy", Info(Title = "Dummy API")) |> ignore
        ) |> ignore

        ()

    member this.Configure(app: IApplicationBuilder, env: IHostingEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseSwagger()
        |> ignore

        app.UseSwaggerUI(fun c ->
            c.SwaggerEndpoint("/swagger/dummy/swagger.json", "Dummy API")
        ) |> ignore


        app.UseMvc();