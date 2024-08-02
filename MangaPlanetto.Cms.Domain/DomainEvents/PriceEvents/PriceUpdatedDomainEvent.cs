using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.DomainEvents.PriceEvents;

/// <summary>
/// Event for when the price gets updated.
/// </summary>
public record PriceUpdatedDomainEvent : IDomainEvent
{
    public MangaId MangaId { get; private set; }
    public Price OldPrice { get; private set; }
    public Price NewPrice { get; private set; }

    public Guid Id { get; }

    public PriceUpdatedDomainEvent(
        MangaId mangaId,
        Price oldPrice,
        Price newPrice)
    {
        this.Id = Guid.NewGuid();
        this.MangaId = mangaId;
        this.OldPrice = oldPrice;
        this.NewPrice = newPrice;
    }
}
