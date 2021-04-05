namespace Hqv.Dominoes.WebApplication.Events
{
    public interface IDominoesEvent
    {
        string CorrelationId { get; }
        string EventId { get; }
        string EventName { get; }
        int Version { get; }
    }
}