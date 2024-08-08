using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.Repositories;

namespace MangaPlanetto.Cms.Application.MangaUseCases.MangaUpdating;

public sealed class UpdateMangaPriceCommandHandler(
    IMangaRepository mangaRepository) : ICommandHandler<UpdateMangaPriceCommand, MangaId>
{
    private readonly IMangaRepository _mangaRepository = mangaRepository;

    public async Task<MangaId> Handle(UpdateMangaPriceCommand request, CancellationToken cancellationToken)
    {
        MangaId? result = await this._mangaRepository.UpdateMangaPriceAsync(
            request.MangaId,
            request.Currency,
            request.Value,
            cancellationToken);

        await this._mangaRepository.SaveMangaChangesAsync(cancellationToken);

        return result;
    }
}
