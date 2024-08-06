using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.DomainEvents.Manga;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.Entities.Mangas;

/// <summary>
/// Represents a manga.
/// </summary>
public sealed class Manga : AggregateRoot<MangaId>
{
    private Manga(MangaId id)
        : base(id)
    {
    }

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
            MangaId.CreateMangaId())
        {
            Title = title,
            Price = price
        };

        return manga;
    }

    /// <summary>
    /// Given a new price, updates the current price.
    /// </summary>
    /// <param name="newPrice">Incoming price change.</param>
    public void UpdatePrice(
        string currency,
        decimal value)
    {
        Price newPrice = Price.CreatePrice(
            currency,
            value);

        Price oldPrice = this.Price;
        this.Price = newPrice;

        PriceUpdatedDomainEvent priceUpdatedEvent =
            new(this.Id, oldPrice, newPrice);

        this.AddDomainEvent(priceUpdatedEvent);
    }
}
