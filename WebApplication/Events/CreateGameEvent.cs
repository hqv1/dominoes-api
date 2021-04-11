using System;

namespace Hqv.Dominoes.WebApplication.Events
{
    public class CreateGameEvent : IDominoesEvent
    {
        public CreateGameEvent(string correlationId, bool isTest, bool isDebug, Player player)
        {
            EventId = Guid.NewGuid().ToString();
            EventName = nameof(CreateGameEvent);
            Version = 1;

            CorrelationId = correlationId;
            IsTest = isTest;
            IsDebug = isDebug;
            Player = player;
        }

        public string CorrelationId { get; }
        public bool IsTest { get; }
        public bool IsDebug { get; }
        public string EventId { get; }
        public string EventName { get; }
        public int Version { get; }
        public Player Player { get; }
    }
}