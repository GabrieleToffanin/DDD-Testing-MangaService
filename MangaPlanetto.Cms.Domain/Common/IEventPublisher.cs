namespace MangaPlanetto.Cms.Domain.Common;

public interface IEventPublisher
{
    Task Publish<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken)
        where TEvent : notnull;
}
