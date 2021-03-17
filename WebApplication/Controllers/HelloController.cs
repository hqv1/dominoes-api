using Microsoft.AspNetCore.Mvc;

namespace Hqv.Dominoes.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}