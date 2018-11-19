using DummyAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DummyAPI.Controllers
{
    public class PostHttpPostRequestBody
    {
        [Required]
        public string Content { get; internal set; }
        [Required]
        public string Title { get; internal set; }
        public int AuthorId { get; internal set; }
        public int BlogId { get; internal set; }
    }

    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private BloggingContext _dbContext;

        public PostsController(BloggingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("1")]
        public async Task<IActionResult> GetAll1()
        {
            var result = (await _dbContext.Blogs
                .AsNoTracking()
                .Include(b => b.Posts)
                .ThenInclude(p => p.Author)
                .ToListAsync())
                .Select(b => new
                {
                    url = b.Url,
                    posts = b.Posts.Select(p => new { title = p.Title, author = p.Author.Name })
                });

            return Ok(result);
        }

        [HttpGet("2")]
        public async Task<IActionResult> GetAll2()
        {
            var result = (await _dbContext.Blogs
                .Select(b => new
                {
                    url = b.Url,
                    posts = b.Posts.Select(p => new { title = p.Title, author = p.Author.Name })
                })
                .ToListAsync());

            return Ok(result);
        }

        [HttpGet("1/{postId}")]
        public async Task<ActionResult<PostRecord>> Get(int postId)
        {
            var post = await _dbContext.Posts.AsNoTracking().SingleAsync(p => p.Id == postId);
            post.Content = post.Content + " - Added";
            await _dbContext.SaveChangesAsync();
            return Ok(post);
        }

        [HttpGet("2/{postId}")]
        public async Task<IActionResult> Get2(int postId)
        {
            var post = await _dbContext.Posts.FindAsync(postId);
            post.Content = post.Content + " - Added";
            await _dbContext.SaveChangesAsync();
            return Ok(post);
        }

        [HttpPost]
        public async Task Post(PostHttpPostRequestBody body)
        {
            _dbContext.Add(new PostRecord
            {
                AuthorId = body.AuthorId,
                BlogId = body.BlogId,
                Content = body.Content,
                Title = body.Title
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
