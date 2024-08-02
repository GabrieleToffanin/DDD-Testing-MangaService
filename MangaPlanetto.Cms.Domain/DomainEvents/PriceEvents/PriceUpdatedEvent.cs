using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.DomainEvents.PriceEvents;
public sealed class PriceUpdatedEvent : IDomainEvent
{
    public MangaId MangaId { get; private set; }
    public Price OldPrice { get; private set; }
    public Price NewPrice { get; private set; }

    public PriceUpdatedEvent(
        MangaId mangaId,
        Price oldPrice,
        Price newPrice)
    {
        this.MangaId = mangaId;
        this.OldPrice = oldPrice;
        this.NewPrice = newPrice;
    }
}
