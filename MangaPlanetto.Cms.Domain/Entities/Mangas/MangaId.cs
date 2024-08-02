namespace MangaPlanetto.Cms.Domain.Entities.Mangas;

public sealed record MangaId
{
    public Guid Value { get; init; }

    private MangaId()
    {
        this.Value = Guid.NewGuid();
    }

    public static MangaId CreateMangaId()
    => new MangaId();
}
