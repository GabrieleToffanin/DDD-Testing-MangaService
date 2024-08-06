using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;

namespace MangaPlanetto.Cms.Application.MangaUseCases.MangaUpdating;

public class UpdateMangaPriceCommand : ICommand<MangaId>
{
    public UpdateMangaPriceCommand(
        MangaId mangaId,
        string currency,
        decimal value)
    {
        this.MangaId = mangaId;
        this.Currency = currency;
        this.Value = value;
    }

    public MangaId MangaId { get; }

    public string Currency { get; }

    public decimal Value { get; }
}
