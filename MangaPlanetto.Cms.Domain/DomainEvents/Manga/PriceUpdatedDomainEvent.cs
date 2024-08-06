using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.DomainEvents.Manga;

/// <summary>
/// Event for when the price gets updated.
/// </summary>
public record PriceUpdatedDomainEvent : IDomainEvent
{
    public MangaId MangaId { get; }
    public Price OldPrice { get; }
    public Price NewPrice { get; }

    public Guid Id { get; }

    public DateTime OccurredOn { get; }

    public PriceUpdatedDomainEvent(
        MangaId mangaId,
        Price oldPrice,
        Price newPrice)
    {
        this.Id = Guid.NewGuid();
        this.MangaId = mangaId;
        this.OldPrice = oldPrice;
        this.NewPrice = newPrice;
        this.OccurredOn = DateTime.UtcNow;
    }
}
