using DummyAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DummyAPI.Controllers
{
    public class AuthorHttpPostRequestBody
    {
        [Required]
        public string Name { get; set; }
    }

    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private BloggingContext _dbContext;

        public AuthorsController(BloggingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<List<AuthorRecord>>> GetAll()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<ActionResult<AuthorRecord>> Get(int blogId)
        {
            return await _dbContext.Authors.FindAsync(blogId);
        }

        public async Task Post(AuthorHttpPostRequestBody body)
        {
            _dbContext.Add(new AuthorRecord {
                Name = body.Name
            });
            await _dbContext.SaveChangesAsync();
        }
    }
}
