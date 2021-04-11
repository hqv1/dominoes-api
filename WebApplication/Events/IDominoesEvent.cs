namespace Hqv.Dominoes.WebApplication.Events
{
    public interface IDominoesEvent
    {
        string CorrelationId { get; }
        bool IsTest { get; }
        bool IsDebug { get; }
        string EventId { get; }
        string EventName { get; }
        int Version { get; }
    }
}