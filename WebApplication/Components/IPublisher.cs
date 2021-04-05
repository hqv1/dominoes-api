using System.Threading.Tasks;
using Hqv.Dominoes.WebApplication.Events;

namespace Hqv.Dominoes.WebApplication.Components
{
    public interface IPublisher
    {
        Task Publish(CreateGameEvent createGameEvent);
    }
}