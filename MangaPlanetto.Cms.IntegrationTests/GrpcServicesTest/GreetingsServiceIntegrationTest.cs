
using MangaPlanetto.Cms.Api;
using MangaPlanetto.Cms.IntegrationTests.GrpcServicesTest.Common;
using Xunit.Abstractions;

namespace MangaPlanetto.Cms.IntegrationTests.GrpcServicesTest;

public sealed class GreetingsServiceIntegrationTest(
    GrpcTestFixture<Startup> fixture,
    ITestOutputHelper outputHelper) : IntegrationTestBase(fixture, outputHelper)
{

    [Fact]
    public async Task SayHelloUnaryTest()
    {
        Manga.MangaClient client = new(this.Channel);

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

        UpdatedMangaResponse test =
            await client.UpdateMangaPriceAsync(updatePrice);

        Assert.Equal(mangaId, test.MangaId);
    }
}
