using System.Threading.Tasks;
using Hqv.Dominoes.WebApplication.Models;
using Hqv.Dominoes.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hqv.Dominoes.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly ILogger<GameController> _logger;

        public GameController(GameService gameService, ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGameModel createGameModel, [FromHeader] string correlationId)
        {
            _logger.LogInformation("Received Create Game Request");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createGameBag = new CreateGameBag(correlationId, createGameModel);
            await _gameService.Create(createGameBag);
            return Ok();
        }
    }
}