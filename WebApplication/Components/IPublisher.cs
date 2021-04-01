using Hqv.Dominoes.WebApplication.Events;

namespace Hqv.Dominoes.WebApplication.Components
{
    public interface IPublisher
    {
        void Publish(CreateGameEvent createGameEvent);
    }
}