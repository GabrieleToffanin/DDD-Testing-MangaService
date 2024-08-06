namespace MangaPlanetto.Cms.Domain.Common;

public interface IEvP
{
    Task Publish<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken)
        where TEvent : notnull;
}
