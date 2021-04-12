using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Hqv.Dominoes.WebApplication.Components;
using Hqv.Dominoes.WebApplication.Events;
using Hqv.Dominoes.WebApplication.Services;
using Hqv.Dominoes.WebApplication.Test.Generator;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Hqv.Dominoes.WebApplication.Test
{
    public class GameServiceTest
    {
        private readonly GameService _gameService;
        private readonly Mock<ILogger<GameService>> _mockedLogger;
        private readonly Mock<IMapper> _mockedMapper;
        private readonly Mock<IPublisher> _mockedPublisher;
        private readonly TestDataCreator _testDataCreator;

        public GameServiceTest()
        {
            _mockedLogger = new Mock<ILogger<GameService>>();
            _mockedMapper = new Mock<IMapper>();
            _mockedPublisher = new Mock<IPublisher>();
            
            _gameService = new GameService(_mockedLogger.Object, _mockedMapper.Object, _mockedPublisher.Object);

            _testDataCreator = new TestDataCreator();
        }

        [Fact]
        public void ShouldCreate()
        {
            // Given Create Game Model
            var inputCreateGameBag = _testDataCreator.GenerateCreateGameBag();
            var createGameEvent = _testDataCreator.GenerateCreateGameEvent();

            _mockedMapper.Setup(x => x.Map<CreateGameEvent>(inputCreateGameBag)).Returns(createGameEvent);
            
            // When Create is Called
            _gameService.Create(inputCreateGameBag);
            
            // Then methods are called
            _mockedMapper.Verify(x=>x.Map<CreateGameEvent>(inputCreateGameBag));
            _mockedPublisher.Verify(x=>x.Publish(createGameEvent));
        }
    }
}