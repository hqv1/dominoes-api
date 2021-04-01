using Hqv.Dominoes.WebApplication.Components;
using Hqv.Dominoes.WebApplication.Services;
using Moq;

namespace Hqv.Dominoes.WebApplication.Test
{
    public class CreateGameTest
    {
        // private readonly Faker<CreateGameModel> _testCreateGameModels;
        // private readonly Mock<IPublisher> _mockedPublisher;
        // private readonly GameService _gameService;
        //
        // private CreateGameModel _inputCreateGameModel;
        //
        // public CreateGameTest()
        // {
        //     var testPlayers = new Faker<PlayerModel>()
        //         .StrictMode(true)
        //         .RuleFor(p=>p.Id, f=>f.Random.String(10))
        //         .RuleFor(p => p.Name, f => f.Name.FullName())
        //         .RuleFor(p => p.IpAddress, f => f.Internet.IpAddress().ToString() );
        //
        //     _testCreateGameModels = new Faker<CreateGameModel>()
        //         .StrictMode(true)
        //         .RuleFor(p => p.Player, testPlayers.Generate());
        //
        //     _mockedPublisher = new Mock<IPublisher>();
        //     //_gameService = new GameService(_mockedPublisher.Object);
        // }
        //
        // [Fact]
        // public void ShouldPublishCreateGameEvent()
        // {
        //     GivenCreateGameModel();
        //     WhenCreateGameServiceIsCalled();
        //     // ThenCreateGameEventIsPublished();
        // }
        //
        // private void GivenCreateGameModel()
        // {
        //     _inputCreateGameModel = _testCreateGameModels.Generate();
        // }
        //
        // private void WhenCreateGameServiceIsCalled()
        // {
        //     _gameService.Create(_inputCreateGameModel);
        // }
    }
}