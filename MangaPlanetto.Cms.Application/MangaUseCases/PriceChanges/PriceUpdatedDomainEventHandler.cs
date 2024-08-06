using MangaPlanetto.Cms.Domain.DomainEvents.Manga;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MassTransit;
using MediatR;

namespace MangaPlanetto.Cms.Application.MangaUseCases.PriceChanges;

public sealed class PriceUpdatedDomainEventHandler(
    IBus bus) :
    INotificationHandler<PriceUpdatedDomainEvent>
{
    private readonly IBus _bus = bus;

    public async Task Handle(PriceUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        //Still missing update the manga

        PriceUpdatedEvent priceUpdatedEvent = new(notification.Id, MangaId.CreateMangaId());

        await _bus.Publish(priceUpdatedEvent, cancellationToken);
    }
}
