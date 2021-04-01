using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Events
{
    public class CreateGameEvent
    {
        public CreateGameEvent(PlayerModel player)
        {
            Player = player;
        }
        public PlayerModel Player { get; }
    }
}