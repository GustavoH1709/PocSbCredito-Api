using Microsoft.AspNetCore.Mvc;

namespace PocSbCredito.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index() => Ok("Online...");
    }
}
