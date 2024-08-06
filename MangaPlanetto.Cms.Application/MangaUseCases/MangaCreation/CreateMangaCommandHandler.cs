using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Infrastructure.DatabaseContext;

namespace MangaPlanetto.Cms.Application.MangaUseCases.MangaCreation;
public sealed class CreateMangaCommandHandler(
    MangaContext mangaContext) : ICommandHandler<CreateMangaCommand, MangaId>
{
    public async Task<MangaId> Handle(CreateMangaCommand request, CancellationToken cancellationToken)
    {
        var result = await mangaContext.Mangas.AddAsync(Manga.CreateManga(request.title, request.currency, request.value));

        await mangaContext.SaveChangesAsync(cancellationToken);

        return result.Entity.Id;
    }
}
