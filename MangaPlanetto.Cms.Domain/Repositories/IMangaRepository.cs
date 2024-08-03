using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.Repositories;

public interface IMangaRepository
{
    Task<Manga> GetByIdAsync(MangaId id);

    Task<MangaId> UpdateMangaPriceAsync(
        Price price,
        CancellationToken cancellationToken);
}
