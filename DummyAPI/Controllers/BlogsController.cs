using DummyAPI.Monitoring;
using DummyAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DummyAPI.Controllers
{
    public class BlogHttpPostRequestBody
    {
        [Required]
        public string Url { get; set; }
    }

    [ApiController]
    [Route("api/blogs")]
    public class BlogsController : ControllerBase
    {
        private BloggingContext _dbContext;

        public BlogsController(BloggingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogRecord>>> GetAll()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        [HttpGet("{blogId}")]
        [Monitor]
        public async Task<ActionResult<BlogRecord>> Get(int blogId)
        {
            return await _dbContext.Blogs.FindAsync(blogId);
        }

        [HttpPost]
        public async Task Post(BlogHttpPostRequestBody body)
        {
            _dbContext.Add(new BlogRecord
            {
                Url = body.Url
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
