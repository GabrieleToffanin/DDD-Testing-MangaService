using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.Repositories;
using MangaPlanetto.Cms.Infrastructure.DatabaseContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MangaPlanetto.Cms.Infrastructure.Repositories;

internal sealed class MangaRepository(
    MangaContext dbContext,
    IMediator mediator) : IMangaRepository
{
    private readonly MangaContext _dbContext = dbContext;
    private readonly IMediator _mediator = mediator;

    public async Task<MangaId> CreateMangaAsync(
        Manga mangaToBeCreated,
        CancellationToken cancellationToken)
    {
        var createdManga = await this._dbContext.Mangas
            .AddAsync(mangaToBeCreated, cancellationToken);

        return createdManga.Entity.Id;
    }

    public async Task<MangaId> UpdateMangaPriceAsync(MangaId mangaId, string currency, decimal value, CancellationToken cancellationToken)
    {
        Manga? currentManga = await this.GetMangaById(mangaId, cancellationToken);

        currentManga!.UpdatePrice(currency, value);

        return currentManga.Id;
    }

    public async Task SaveMangaChangesAsync(CancellationToken cancellationToken)
    {
        IEnumerable<IDomainEvent> domainEvents =
            this._dbContext.ChangeTracker.Entries<Manga>()
                                         .Where(e => e.Entity.DomainEvents.Any())
                                         .SelectMany(e => e.Entity.DomainEvents)
                                         .ToList();

        foreach (IDomainEvent domainEvent in domainEvents)
            await this._mediator.Publish(domainEvent, cancellationToken);

        await this._dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task<Manga?> GetMangaById(MangaId mangaId, CancellationToken cancellationToken)
    {
        return await this._dbContext.Mangas
            .FirstOrDefaultAsync(manga => manga.Id == mangaId, cancellationToken);
    }
}
