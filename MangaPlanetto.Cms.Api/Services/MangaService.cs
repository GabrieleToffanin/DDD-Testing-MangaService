
using Grpc.Core;
using MangaPlanetto.Cms.Application.Manga.Abstractions;

namespace MangaPlanetto.Cms.Api.Services;

public class MangaService(
    ILogger<MangaService> logger,
    IMangaService mangaService) : Manga.MangaBase
{
    private readonly ILogger<MangaService> _logger = logger;
    private readonly IMangaService _mangaService = mangaService;

    public override Task<GetMangaResponse> GetManga(
        GetMangaRequest request,
        ServerCallContext context)
    {
        return base.GetManga(request, context);
    }

    public override async Task<UpdatedMangaResponse> UpdateMangaPrice(
        UpdateMangaPriceRequest request,
        ServerCallContext context)
    {
        var result = await this._mangaService.UpdateMangaPriceAsync(
            new Guid(request.MangaId),
            request.Price.Currency,
            (decimal)request.Price.Amount,
            context.CancellationToken);

        UpdatedMangaResponse response = new()
        {
            MangaId = result.ToString(),
        };

        return response;
    }
}
