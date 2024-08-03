namespace MangaPlanetto.Cms.Application.Manga.Abstractions;

public interface IMangaService
{
    Task<Guid> UpdateMangaPriceAsync(
        Guid mangaId,
        string currency,
        decimal newPrice,
        CancellationToken cancellationToken);
}
