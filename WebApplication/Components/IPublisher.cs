using System.Threading.Tasks;
using Hqv.Dominoes.Shared.Events.Game;

namespace Hqv.Dominoes.WebApplication.Components
{
    public interface IPublisher
    {
        Task Publish(CreateGameEvent createGameEvent);
    }
}