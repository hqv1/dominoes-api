using Bogus;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Test.Generator
{
    /// <summary>
    /// Create test data
    /// </summary>
    public class TestDataCreator
    {
        private readonly Faker<CreateGameModel> _testCreateGameModels;

        public TestDataCreator()
        {
            var testPlayers = new Faker<PlayerModel>()
                .StrictMode(true)
                .RuleFor(p=>p.Id, f=>f.Random.String(10))
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.IpAddress, f => f.Internet.IpAddress().ToString() );

            _testCreateGameModels = new Faker<CreateGameModel>()
                .StrictMode(true)
                .RuleFor(p => p.Player, testPlayers.Generate());

        }

        public CreateGameModel GenerateCreateGameModel()
        {
            return _testCreateGameModels.Generate();
        }
    }
}