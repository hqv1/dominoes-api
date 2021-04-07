using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hqv.Dominoes.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Received Hello World request");
            return "Hello World";
        }
    }
}