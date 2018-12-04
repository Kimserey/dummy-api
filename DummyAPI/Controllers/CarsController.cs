using Microsoft.AspNetCore.Mvc;
using DummyAPI.Models;

namespace DummyAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Car[]> GetAll()
        {
            return new[] {
                new Car { Id = 1, Name = "BMW" },
                new Car { Id = 2, Name = "Mercedes" },
                new Car { Id = 3, Name = "Audi" }
            };
        }
    }
}
