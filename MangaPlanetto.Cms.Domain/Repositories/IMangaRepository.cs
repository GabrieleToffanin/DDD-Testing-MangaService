using MangaPlanetto.Cms.Domain.Entities.Mangas;

namespace MangaPlanetto.Cms.Domain.Repositories;

public interface IMangaRepository
{
    Task<MangaId> CreateMangaAsync(
        Manga mangaToBeCreated,
        CancellationToken cancellationToken);

    Task<MangaId> UpdateMangaPriceAsync(
        MangaId mangaId,
        string currency,
        decimal value,
        CancellationToken cancellationToken);

    Task SaveMangaChangesAsync(CancellationToken cancellationToken);
}
