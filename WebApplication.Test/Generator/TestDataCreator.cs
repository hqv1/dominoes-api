using Bogus;
using Hqv.Dominoes.Shared.Events.Common;
using Hqv.Dominoes.Shared.Events.Game;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Test.Generator
{
    /// <summary>
    /// Create test data
    /// </summary>
    public class TestDataCreator
    {
        private readonly Faker<CreateGameBag> _testCreateGameBags;
        private readonly Faker<CreateGameModel> _testCreateGameModels;
        
        public TestDataCreator()
        {
            var testPlayerModels = new Faker<PlayerModel>()
                .StrictMode(true)
                .RuleFor(p=>p.Id, f=>f.Random.AlphaNumeric(10))
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.IpAddress, f => f.Internet.IpAddress().ToString() );

            _testCreateGameModels = new Faker<CreateGameModel>()
                .StrictMode(true)
                .RuleFor(m=>m.IsDebug, f=>f.Random.Bool())
                .RuleFor(m=>m.IsTest, f=>f.Random.Bool())
                .RuleFor(p => p.Player, testPlayerModels.Generate());

            _testCreateGameBags = new Faker<CreateGameBag>()
                .CustomInstantiator(f => new CreateGameBag(
                    f.Random.AlphaNumeric(10),
                    _testCreateGameModels.Generate()
                ));
            
            var testPlayer = new Faker<Player>()
                .CustomInstantiator(f => new Player(
                    f.Random.AlphaNumeric(10),
                    f.Name.FullName(),
                    f.Internet.IpAddress().ToString()
                ));

        }

        public CreateGameModel GenerateCreateGameModel()
        {
            return _testCreateGameModels.Generate();
        }

        public CreateGameBag GenerateCreateGameBag()
        {
            return _testCreateGameBags.Generate();
        }
    }
}