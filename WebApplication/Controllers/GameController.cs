using System.Threading.Tasks;
using Hqv.Dominoes.WebApplication.Models;
using Hqv.Dominoes.WebApplication.Services;
using Hqv.Dominoes.WebApplication.Setup;
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
            _logger.LogDebugOrElevate(createGameModel.IsDebug, "Received Create Game Request");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _gameService.Create(new CreateGameBag(correlationId, createGameModel));
            return Ok();
        }
    }
}