module DummyAPI.FSharp.Persistence

open Microsoft.EntityFrameworkCore
open System

//[<CLIMutable>]
//type BlogRecord =
//    {
//        id: int
//        url: string
//        creationDate: Nullable<DateTimeOffset>
//    }

type BlogRecord() =
    member val id = Unchecked.defaultof<int> with get, set
    member val url = Unchecked.defaultof<string> with get, set
    member val creationDate = Unchecked.defaultof<Nullable<DateTimeOffset>> with get, set

type BloggingContext(opts: DbContextOptions<BloggingContext>) =
    inherit DbContext(opts)

    [<DefaultValue>]
    val mutable blogs: DbSet<BlogRecord>
    member this.Blogs
        with get() = this.blogs
        and set v = this.blogs <- v
