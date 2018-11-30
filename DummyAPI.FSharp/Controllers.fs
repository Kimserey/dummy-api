namespace DummyAPI.FSharp

open System
open System.Linq
open Microsoft.AspNetCore.Mvc
open Persistence

[<ApiController>]
[<Route("api/blogs")>]
type BlogsController(context: BloggingContext) =
    inherit ControllerBase()

    [<HttpGet>]
    member __.GetAllBlogs() =
        let now = DateTimeOffset.Now
        context.Blogs.Where(fun x -> x.creationDate.HasValue && x.creationDate.Value < now).ToList()