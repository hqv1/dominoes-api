using System.Threading.Tasks;
using AutoMapper;
using Hqv.Dominoes.WebApplication.Components;
using Hqv.Dominoes.WebApplication.Events;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Services
{
    public class GameService
    {
        private readonly IMapper _mapper;
        private readonly IPublisher _publisher;

        public GameService(IMapper mapper, IPublisher publisher)
        {
            _mapper = mapper;
            _publisher = publisher;
        }
        
        public async Task Create(CreateGameBag createGameBag)
        {
            var createGameEvent = _mapper.Map<CreateGameEvent>(createGameBag);
            await _publisher.Publish(createGameEvent);
        }
    }
}