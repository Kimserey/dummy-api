using DummyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DummyAPI.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompaniesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Person[]> GetAll([FromServices] ILogger<PersonsController> logger)
        {
            logger.LogInformation("Get all companies.");

            return new[] {
                new Person { Name = "Microsoft" },
                new Person { Name = "Thomson Reuters" },
                new Person { Name = "Bloomberg" },
            };
        }
    }
}
