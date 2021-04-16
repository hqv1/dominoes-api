using System.Threading.Tasks;
using AutoMapper;
using Hqv.Dominoes.Shared.Events.Game;
using Hqv.Dominoes.WebApplication.Components;
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
            var createGameEvent = _mapper.Map<CreateGameEvent>(createGameBag);
            _logger.LogDebugOrElevate(createGameEvent.IsDebug, "Event created. {@Event}", createGameEvent);
            await _publisher.Publish(createGameEvent);
        }
    }
}