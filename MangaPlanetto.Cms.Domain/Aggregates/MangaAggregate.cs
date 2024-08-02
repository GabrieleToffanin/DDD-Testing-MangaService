using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.Aggregates;

public sealed class MangaAggregate
{
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

    public static MangaAggregate CreateMangaAggregate(
        Manga manga,
        Price price)
    {
        return new MangaAggregate(manga, price);
    }
}
