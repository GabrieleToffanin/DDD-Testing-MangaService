using MangaPlanetto.Cms.Domain.Common;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using Microsoft.EntityFrameworkCore;

namespace MangaPlanetto.Cms.Infrastructure.DatabaseContext;
public sealed class MangaContext : DbContext
{
    private readonly IEvP _eventPublisher;

    public MangaContext(
        DbContextOptions<MangaContext> options,
        IEvP eventPublisher) : base(options)
    {
        this.Database.EnsureCreated();
        this._eventPublisher = eventPublisher;
    }

    public DbSet<Manga> Mangas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Add manga configuration to the model builder
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MangaContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        //TODO: at the moment this is hardcoded to be working just for
        // Manga entity. It should be refactored to work with all entities
        var domainEvents = ChangeTracker.Entries<Manga>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .SelectMany(e => e.DomainEvents);

        foreach (var domainEvent in domainEvents)
            await this._eventPublisher.Publish(domainEvent, cancellationToken);

        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}
