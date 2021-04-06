using System;

namespace Hqv.Dominoes.WebApplication.Events
{
    public class CreateGameEvent : IDominoesEvent
    {
        public CreateGameEvent(string? correlationId, Player player)
        {
            EventId = Guid.NewGuid().ToString();
            EventName = nameof(CreateGameEvent);
            Version = 1;

            CorrelationId = correlationId ?? Guid.NewGuid().ToString();
            Player = player;
        }

        public string CorrelationId { get; }
        public string EventId { get; }
        public string EventName { get; }
        public int Version { get; }
        public Player Player { get; }
    }
}