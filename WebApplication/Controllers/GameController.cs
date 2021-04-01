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
        public void Post([FromBody] CreateGameModel createGameModel)
        {
            _gameService.Create(createGameModel);
        }
    }
}