namespace MangaPlanetto.Cms.Domain.Entities.Mangas;

/// <summary>
/// Represents a manga.
/// </summary>
public sealed class Manga
{
    private Manga(
        string title)
    {
        this.Id = MangaId.CreateMangaId();
        this.Title = title;
    }

    public MangaId Id { get; set; }

    public string Title { get; set; }

    public static Manga CreateManga(
        string title)
    {
        //TODO: Add validation

        Manga manga = new(title);

        return manga;
    }
}
