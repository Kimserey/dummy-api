using Microsoft.AspNetCore.Mvc;

namespace DummyAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        public string Get()
        {
            return "Dummy API Running";
        }
    }
}
