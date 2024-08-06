using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MangaPlanetto.Cms.Application.MangaUseCases.MangaUpdating;

public sealed class UpdateMangaPriceCommandHandler(MangaContext mangaContext)
    : ICommandHandler<UpdateMangaPriceCommand, MangaId>
{
    public async Task<MangaId> Handle(UpdateMangaPriceCommand request, CancellationToken cancellationToken)
    {
        Manga? currentManga = await mangaContext.Mangas.FirstOrDefaultAsync(manga => manga.Id == request.MangaId, cancellationToken: cancellationToken);

        currentManga!.UpdatePrice(request.Currency, request.Value);

        await mangaContext.SaveChangesAsync(cancellationToken);

        return currentManga.Id;
    }
}
