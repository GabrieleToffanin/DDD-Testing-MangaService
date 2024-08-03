using MangaPlanetto.Cms.Api.Services;
using MangaPlanetto.Cms.Infrastructure.DependencyInjection;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMediator();
        services.AddGrpc();
        services.AddEventPublisher();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<MangaService>();
            endpoints.MapGet("/", context =>
            {
                return context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            });
        });
    }
}