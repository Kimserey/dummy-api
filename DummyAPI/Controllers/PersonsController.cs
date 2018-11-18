using DummyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DummyAPI.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        public ActionResult<Person[]> GetAll([FromServices] ILogger<PersonsController> logger)
        {
            logger.LogInformation("Get All called.");

            return new[] {
                new Person { Name = "Kim" },
                new Person { Name = "Tom" },
                new Person { Name = "Sam" },
            };
        }
    }
}
