using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.ValueObjects;

namespace MangaPlanetto.Cms.Domain.Repositories;

public interface IMangaRepository
{
    Task<MangaId> UpdateMangaPrice(
        Price price,
        CancellationToken cancellationToken);
}
