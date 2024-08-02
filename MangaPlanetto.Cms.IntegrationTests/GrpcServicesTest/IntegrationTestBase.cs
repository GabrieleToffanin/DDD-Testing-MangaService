//RIghts to https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/grpc/test-services/sample/Tests/Server/IntegrationTests/IntegrationTestBase.cs

using Grpc.Net.Client;
using MangaPlanetto.Cms.IntegrationTests.GrpcServicesTest.Common;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MangaPlanetto.Cms.IntegrationTests.GrpcServicesTest;

public class IntegrationTestBase : IClassFixture<GrpcTestFixture<Startup>>, IDisposable
{
    private GrpcChannel? _channel;
    private IDisposable? _testContext;

    protected GrpcTestFixture<Startup> Fixture { get; set; }

    protected ILoggerFactory LoggerFactory => Fixture.LoggerFactory;

    protected GrpcChannel Channel => _channel ??= CreateChannel();

    protected GrpcChannel CreateChannel()
    {
        return GrpcChannel.ForAddress("http://testhost", new GrpcChannelOptions
        {
            LoggerFactory = this.LoggerFactory,
            HttpHandler = this.Fixture.Handler
        });
    }

    public IntegrationTestBase(GrpcTestFixture<Startup> fixture, ITestOutputHelper outputHelper)
    {
        this.Fixture = fixture;
        this._testContext = this.Fixture.GetTestContext(outputHelper);
    }

    public void Dispose()
    {
        this._testContext?.Dispose();
        this._channel = null;
    }
}
