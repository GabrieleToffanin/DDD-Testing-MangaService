using MangaPlanetto.Cms.Domain.Entities.Mangas;
using Microsoft.EntityFrameworkCore;

namespace MangaPlanetto.Cms.Infrastructure.DatabaseContext;
public sealed class MangaContext : DbContext
{
    public MangaContext(
        DbContextOptions<MangaContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<Manga> Mangas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Add manga configuration to the model builder
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MangaContext).Assembly);
    }
}
