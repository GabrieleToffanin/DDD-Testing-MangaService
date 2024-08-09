using MangaPlanetto.Cms.Domain.Entities.Mangas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MangaPlanetto.Cms.Infrastructure.DatabaseContext.Configuration;

internal sealed class MangaConfiguration : IEntityTypeConfiguration<Manga>
{
    public void Configure(EntityTypeBuilder<Manga> builder)
    {
        builder.OwnsOne(m => m.Price, price =>
                {
                    price.Property(p => p.Value);
                    price.Property(p => p.CurrencyValue);
                });

        builder.OwnsMany(m => m.DomainEvents);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => MangaId.FastCreate(v));

        builder.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(255);
    }
}
