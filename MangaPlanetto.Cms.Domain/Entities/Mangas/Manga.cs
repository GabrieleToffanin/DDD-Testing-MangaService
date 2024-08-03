using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.DomainEvents.PriceEvents;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.Entities.Mangas;

/// <summary>
/// Represents a manga.
/// </summary>
public sealed class Manga : AggregateRoot<MangaId>
{
    private Manga(
        MangaId id,
        string title,
        Price price)
        : base(id)
    {
        this.Id = id;
        this.Title = title;
        this.Price = price;
    }

    public MangaId Id { get; internal set; }

    public string Title { get; internal set; }

    public Price Price { get; internal set; }

    public static Manga CreateManga(
        string title,
        string currency,
        decimal value)
    {
        //TODO: Add validation

        Price price = Price.CreatePrice(
            currency,
            value);

        Manga manga = new(
            MangaId.CreateMangaId(),
            title,
            price);

        return manga;
    }

    /// <summary>
    /// Given a new price, updates the current price.
    /// </summary>
    /// <param name="newPrice">Incoming price change.</param>
    public void UpdatePrice(Price newPrice)
    {
        Price oldPrice = this.Price;
        this.Price = newPrice;

        PriceUpdatedDomainEvent priceUpdatedEvent =
            new(this.Id, oldPrice, newPrice);

        this.AddDomainEvent(priceUpdatedEvent);
    }
}
