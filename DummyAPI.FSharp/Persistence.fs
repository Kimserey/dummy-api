module DummyAPI.FSharp.Persistence

open Microsoft.EntityFrameworkCore
open System

type BlogRecord =
    {
        id: int
        url: string
        creationDate: Nullable<DateTimeOffset>
    }

type BloggingContext(opts: DbContextOptions<BloggingContext>) =
    inherit DbContext(opts)

    [<DefaultValue>]
    val mutable blogs: DbSet<BlogRecord>
    member this.Blogs
        with get() = this.blogs
        and set v = this.blogs <- v
