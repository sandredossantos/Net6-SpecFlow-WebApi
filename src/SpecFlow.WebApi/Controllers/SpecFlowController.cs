using Microsoft.AspNetCore.Mvc;

namespace SpecFlow.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecFlowController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "Red", "Blue", "Yellow", });
        }
    }
}