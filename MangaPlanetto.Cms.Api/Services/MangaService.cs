
using Grpc.Core;
using MangaPlanetto.Cms.Application.Manga;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MediatR;

namespace MangaPlanetto.Cms.Api.Services;

/// <summary>
/// Performs common operations on manga entities.
/// </summary>
/// <param name="mediator"></param>
/// <param name="logger"></param>
public class MangaService(
    IMediator mediator,
    ILogger<MangaService> logger) : Manga.MangaBase
{
    private readonly ILogger<MangaService> _logger = logger;
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Gets a manga by its identifier.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override Task<GetMangaResponse> GetManga(
        GetMangaRequest request,
        ServerCallContext context)
    {
        return base.GetManga(request, context);
    }

    /// <summary>
    /// Updates the price of a manga.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<UpdatedMangaResponse> UpdateMangaPrice(
        UpdateMangaPriceRequest request,
        ServerCallContext context)
    {
        MangaId mangaId = MangaId.ParseFrom(request.MangaId);

        UpdateMangaPriceCommand updateCommand = new(
            mangaId,
            request.Price.Currency,
            (decimal)request.Price.Amount);

        MangaId result = await this._mediator.Send(updateCommand, context.CancellationToken);

        UpdatedMangaResponse response = new()
        {
            MangaId = result.ToString(),
        };

        return response;
    }
}
