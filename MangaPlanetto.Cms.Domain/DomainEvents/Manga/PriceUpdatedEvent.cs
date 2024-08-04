using MangaPlanetto.Cms.Domain.Entities.Mangas;

namespace MangaPlanetto.Cms.Domain.DomainEvents.PriceEvents;

public record PriceUpdatedEvent
{
    public Guid DomainEventId { get; }
    public MangaId MangaId { get; }

    public PriceUpdatedEvent(
        Guid domainEventId,
        MangaId mangaId)
    {
        this.DomainEventId = domainEventId;
        this.MangaId = mangaId;
    }
}
