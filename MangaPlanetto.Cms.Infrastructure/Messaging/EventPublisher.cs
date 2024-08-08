using MangaPlanetto.Cms.Domain.Common;
using MassTransit;

namespace MangaPlanetto.Cms.Infrastructure.Messaging;

/// <summary>
/// Adapter implementation for the amqp event publisher.
/// </summary>
/// <param name="busControl">Control from MassTransit library</param>
public sealed class EventPublisher(
    IBusControl busControl) : IEventPublisher
{
    private readonly IBusControl _busControl = busControl;

    public async Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken)
        where TEvent : notnull
    {
        await this._busControl.Publish(@event, @event.GetType(), cancellationToken);
    }
}
