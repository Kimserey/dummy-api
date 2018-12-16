using Microsoft.AspNetCore.Mvc;

namespace DummyAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Dummy API Running v2";
        }
    }
}
