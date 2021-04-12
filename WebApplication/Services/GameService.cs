using System.Threading.Tasks;
using AutoMapper;
using Hqv.Dominoes.WebApplication.Components;
using Hqv.Dominoes.WebApplication.Events;
using Hqv.Dominoes.WebApplication.Models;
using Hqv.Dominoes.WebApplication.Setup;
using Microsoft.Extensions.Logging;

namespace Hqv.Dominoes.WebApplication.Services
{
    public class GameService
    {
        private readonly ILogger<GameService> _logger;
        private readonly IMapper _mapper;
        private readonly IPublisher _publisher;

        public GameService(ILogger<GameService> logger, IMapper mapper, IPublisher publisher)
        {
            _logger = logger;
            _mapper = mapper;
            _publisher = publisher;
        }
        
        public async Task Create(CreateGameBag createGameBag)
        {
            _logger.LogDebugOrElevate(createGameBag.CreateGameModel.IsDebug, "Mapping model to event");
            var createGameEvent = _mapper.Map<CreateGameEvent>(createGameBag);
            _logger.LogDebugOrElevate(createGameBag.CreateGameModel.IsDebug, "Publishing event");
            await _publisher.Publish(createGameEvent);
            _logger.LogDebugOrElevate(createGameBag.CreateGameModel.IsDebug, "Service complete");
        }
    }
}