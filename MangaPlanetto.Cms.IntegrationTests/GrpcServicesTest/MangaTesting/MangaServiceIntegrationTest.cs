using Grpc.Net.Client;
using MangaPlanetto.Cms.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MangaPlanetto.Cms.IntegrationTests.GrpcServicesTest.MangaTesting;

public sealed class MangaServiceIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly GrpcChannel _channel;

    public MangaServiceIntegrationTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        HttpClient client = _factory.CreateDefaultClient();
        _channel = GrpcChannel.ForAddress(client.BaseAddress!, new GrpcChannelOptions { HttpClient = client });
    }

    [Fact]
    public async Task WhenPriceUpdateRequested_OnExistingManga_PriceIsUpdated()
    {
        // Arrange
        Manga.MangaClient client = new(this._channel);
        string mangaId = Guid.NewGuid().ToString();

        UpdateMangaPriceRequest updatePrice = new()
        {
            MangaId = mangaId,
            Price = new()
            {
                Currency = "USD",
                Amount = 10.0F,
            },
        };

        // Act
        var response = await client.UpdateMangaPriceAsync(updatePrice);

        // Assert
        Assert.Equal(mangaId, response.MangaId);
    }
}
