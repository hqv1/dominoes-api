using System.Threading.Tasks;
using Hqv.Dominoes.WebApplication.Models;
using Hqv.Dominoes.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hqv.Dominoes.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateGameModel createGameModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _gameService.Create(createGameModel);
            return Ok();
        }
    }
}