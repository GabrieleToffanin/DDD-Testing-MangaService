using MangaPlanetto.Cms.Domain.DomainEvents.PriceEvents;
using MangaPlanetto.Cms.Domain.Repositories;
using MassTransit;
using MediatR;

namespace MangaPlanetto.Cms.Application.Manga;

public sealed class PriceUpdatedEventHandler(
    IMangaRepository mangaRepository,
    IBus bus) :
    INotificationHandler<PriceUpdatedDomainEvent>
{
    public async Task Handle(PriceUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var mangaId = await mangaRepository.UpdateMangaPriceAsync(notification.NewPrice, cancellationToken);

        PriceUpdatedEvent priceUpdatedEvent = new(notification.Id, mangaId);

        await bus.Publish(priceUpdatedEvent, cancellationToken);
    }
}
