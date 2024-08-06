using MangaPlanetto.Cms.Domain.DomainEvents.PriceEvents;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MassTransit;
using MediatR;

namespace MangaPlanetto.Cms.Application.Manga;

public sealed class PriceUpdatedDomainEventHandler(
    IBus bus) :
    INotificationHandler<PriceUpdatedDomainEvent>
{
    private readonly IBus _bus = bus;

    public async Task Handle(PriceUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        //Still missing update the manga

        PriceUpdatedEvent priceUpdatedEvent = new(notification.Id, MangaId.CreateMangaId());

        await this._bus.Publish(priceUpdatedEvent, cancellationToken);
    }
}
