using MangaPlanetto.Cms.Api.Services;
using MangaPlanetto.Cms.Application.Manga;
using MangaPlanetto.Cms.Infrastructure.DependencyInjection;
using MangaPlanetto.ServiceDefaults;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        // Configura i servizi
        builder.Services.AddEventPublisher();
        builder.Services.AddMediator(typeof(PriceUpdatedEventHandler).Assembly);
        builder.Services.AddGrpc();

        var app = builder.Build();

        // Configura il middleware
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.MapGrpcService<MangaService>();

        app.MapGet("/", context =>
        {
            return context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
        });

        app.Run();
    }
}