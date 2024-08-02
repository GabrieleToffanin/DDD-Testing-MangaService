
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
        Greeter.GreeterClient client = new(this.Channel);

        HelloRequest helloRequest = new()
        {
            Name = "Gabriele"
        };

        HelloReply test = await client.SayHelloAsync(helloRequest);

        Assert.Equal("Hello Gabriele", test.Message);
    }
}
