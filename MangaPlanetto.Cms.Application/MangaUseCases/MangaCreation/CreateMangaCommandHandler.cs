using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.Repositories;

namespace MangaPlanetto.Cms.Application.MangaUseCases.MangaCreation;
public sealed class CreateMangaCommandHandler(
    IMangaRepository mangaRepository) : ICommandHandler<CreateMangaCommand, MangaId>
{
    private readonly IMangaRepository _mangaRepository = mangaRepository;

    public async Task<MangaId> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
    {
        Manga toBeCreated = Manga.CreateManga(
            request.title,
            request.currency,
            request.value);

        MangaId result = await this._mangaRepository
            .CreateMangaAsync(toBeCreated, cancellationToken);

        await this._mangaRepository.SaveMangaChangesAsync(cancellationToken);

        return result;
    }
}
