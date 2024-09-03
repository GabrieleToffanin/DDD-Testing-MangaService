using Grpc.Net.Client;
using MangaPlanetto.Cms.Api;
using MangaPlanetto.Cms.Domain.Entities.Mangas;
using MangaPlanetto.Cms.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace MangaPlanetto.Cms.IntegrationTests.GrpcServicesTest.MangaTesting;

public sealed class MangaServiceIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly GrpcChannel _channel;

    public MangaServiceIntegrationTest(
        WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        HttpClient client = _factory.CreateDefaultClient();
        _channel = GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions { HttpClient = client });
    }

    [Fact]
    public async Task WhenPriceUpdateRequested_OnExistingManga_PriceIsUpdated()
    {
        // Arrange
        Api.Manga.MangaClient client = new(this._channel);

        CreateMangaRequest createManga = new()
        {
            Title = "Manga Title",
            Price = new GrpcPrice()
            {
                Amount = 5.0F,
                Currency = "USD",
            },
        };

        UpdateMangaPriceRequest updatePrice = new()
        {
            Price = new()
            {
                Currency = "USD",
                Amount = 10.0F,
            },
        };

        // Act
        var response = await client.CreateMangaAsync(createManga);

        updatePrice.MangaId = response.MangaId;

        var updated = await client.UpdateMangaPriceAsync(updatePrice);

        var savedInDb = await this._factory.Services.GetRequiredService<IMangaRepository>().GetMangaAsync(MangaId.ParseFrom(response.MangaId), CancellationToken.None);

        // Assert
        Assert.Equal(10, savedInDb.Price.Value);
    }
}
