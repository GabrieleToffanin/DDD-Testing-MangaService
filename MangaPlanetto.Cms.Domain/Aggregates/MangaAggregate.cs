using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.DomainEvents.PriceEvents;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.ValueObjects;
using System.Collections.Frozen;

namespace MangaPlanetto.Cms.Domain.Aggregates;

public sealed class MangaAggregate
{
    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public FrozenSet<IDomainEvent> DomainEvents => this._domainEvents.ToFrozenSet();

    public Guid Id { get; private set; }

    public Manga Manga { get; private set; }

    public Price Price { get; private set; }

    private MangaAggregate(
        Manga manga,
        Price price)
    {
        this.Id = Guid.NewGuid();
        this.Manga = manga;
        this.Price = price;
    }

    /// <summary>
    /// Creates a new manga aggregate.
    /// Maintaining invariance that a manga must have a price.
    /// </summary>
    /// <param name="manga">Current manga.</param>
    /// <param name="price">Price of the manga.</param>
    /// <returns></returns>
    public static MangaAggregate CreateMangaAggregate(
        Manga manga,
        Price price)
    {
        return new MangaAggregate(manga, price);
    }

    /// <summary>
    /// Given a new price, updates the current price.
    /// </summary>
    /// <param name="newPrice">Incoming price change.</param>
    public void UpdatePrice(Price newPrice)
    {
        var oldPrice = this.Price;
        this.Price = newPrice;

        PriceUpdatedDomainEvent priceUpdatedEvent =
            new(this.Manga.Id, oldPrice, newPrice);

        this._domainEvents.Add(priceUpdatedEvent);
    }

    public void ClearDomainEvents()
        => this._domainEvents.Clear();
}
