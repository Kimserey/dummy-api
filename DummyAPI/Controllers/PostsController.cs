using DummyAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<ActionResult<List<PostRecord>>> GetAll()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<ActionResult<PostRecord>> Get(int postId)
        {
            return await _dbContext.Posts.FindAsync(postId);
        }

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
