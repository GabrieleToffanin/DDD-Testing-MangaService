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
}
