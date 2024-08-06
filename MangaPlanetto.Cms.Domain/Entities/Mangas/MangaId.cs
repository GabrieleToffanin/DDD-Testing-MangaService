using MangaPlanetto.Cms.Domain.Exceptions.Manga;

namespace MangaPlanetto.Cms.Domain.Entities.Mangas;

public sealed record MangaId
{
    public Guid Value { get; init; }

    private MangaId()
    {
        this.Value = Guid.NewGuid();
    }

    private MangaId(Guid value)
    {
        this.Value = value;
    }

    public static MangaId CreateMangaId()
    => new MangaId();

    public static MangaId ParseFrom(string value)
    {
        bool isValid = Guid.TryParse(value, out Guid guid);

        if (!isValid)
            InvalidMangaIdException.ThrowWhenInvalid();

        return new MangaId(guid);
    }

    public static MangaId FastCreate(Guid id) => new MangaId(id);
}
