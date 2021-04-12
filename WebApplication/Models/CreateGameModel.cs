namespace Hqv.Dominoes.WebApplication.Models
{
    public class CreateGameModel
    {
        public bool IsTest { get; set; }
        public bool IsDebug { get; set; }
        public PlayerModel? Player { get; set; }
    }
}