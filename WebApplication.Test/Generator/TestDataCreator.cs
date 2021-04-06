using Bogus;
using Hqv.Dominoes.WebApplication.Events;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Test.Generator
{
    /// <summary>
    /// Create test data
    /// </summary>
    public class TestDataCreator
    {
        private readonly Faker<CreateGameEvent> _testCreateGameEvent;
        private readonly Faker<CreateGameModel> _testCreateGameModels;

        public TestDataCreator()
        {
            var testPlayer = new Faker<Player>()
                .CustomInstantiator(f => new Player(
                    f.Random.AlphaNumeric(10),
                    f.Name.FullName(),
                    f.Internet.IpAddress().ToString()
                ));
            _testCreateGameEvent = new Faker<CreateGameEvent>()
                .CustomInstantiator(f => new CreateGameEvent(
                    f.Random.AlphaNumeric(10),
                    testPlayer.Generate()
                ));
            
            var testPlayerModels = new Faker<PlayerModel>()
                .StrictMode(true)
                .RuleFor(p=>p.Id, f=>f.Random.AlphaNumeric(10))
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.IpAddress, f => f.Internet.IpAddress().ToString() );

            _testCreateGameModels = new Faker<CreateGameModel>()
                .StrictMode(true)
                .RuleFor(m=>m.CorrelationId, f =>f.Random.AlphaNumeric(10))
                .RuleFor(p => p.Player, testPlayerModels.Generate());
        }

        public CreateGameModel GenerateCreateGameModel()
        {
            return _testCreateGameModels.Generate();
        }

        public CreateGameEvent GenerateCreateGameEvent()
        {
            return _testCreateGameEvent.Generate();
        }
    }
}