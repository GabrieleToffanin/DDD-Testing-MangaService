using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;

namespace MangaPlanetto.Cms.Application.Manga;

public sealed class UpdateMangaPriceCommandHandler : ICommandHandler<UpdateMangaPriceCommand, MangaId>
{
    public async Task<MangaId> Handle(UpdateMangaPriceCommand request, CancellationToken cancellationToken)
    {
        return MangaId.CreateMangaId();
    }
}
