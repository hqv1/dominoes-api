namespace Hqv.Dominoes.WebApplication.Models
{
    public class CreateGameBag
    {
        public CreateGameBag(string correlationId, CreateGameModel createGameModel)
        {
            CorrelationId = correlationId;
            CreateGameModel = createGameModel;
        }
        
        public string CorrelationId { get; }
        public CreateGameModel CreateGameModel { get; }
    }
}