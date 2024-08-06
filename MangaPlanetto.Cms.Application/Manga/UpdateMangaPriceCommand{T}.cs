using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;

namespace MangaPlanetto.Cms.Application.Manga;

public class UpdateMangaPriceCommand : ICommand<MangaId>
{
    public UpdateMangaPriceCommand(
        MangaId mangaId,
        string currency,
        decimal value)
    {
        MangaId = mangaId;
        Currency = currency;
        Value = value;
    }

    public MangaId MangaId { get; }

    public string Currency { get; }

    public decimal Value { get; }
}
