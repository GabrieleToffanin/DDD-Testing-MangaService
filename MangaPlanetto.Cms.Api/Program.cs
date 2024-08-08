using MangaPlanetto.Cms.Api.Interceptors;
using MangaPlanetto.Cms.Api.Services;
using MangaPlanetto.Cms.Application.MangaUseCases.PriceChanges;
using MangaPlanetto.Cms.Infrastructure;
using MangaPlanetto.Cms.Infrastructure.DatabaseContext;
using MangaPlanetto.Cms.Infrastructure.DependencyInjection;
using MangaPlanetto.ServiceDefaults;
using Microsoft.OpenApi.Models;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();
        builder.AddCosmosDbContext<MangaContext>("CosmosConnection", "MangaDatabase");

        builder.Services.AddEventPublisher();
        builder.Services.AddRepositories();
        builder.Services.AddMediator(typeof(PriceUpdatedDomainEventHandler).Assembly);

        builder.Services.AddGrpc(
            config =>
            {
                config.EnableDetailedErrors = true;
                config.Interceptors.Add<GrpcExceptionInterceptor>();
            }).AddJsonTranscoding();

        ConfigureSwagger(builder.Services);

        var app = builder.Build();

        // Configura il middleware
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });

        app.MapGrpcService<MangaService>();

        app.MapGet("/", context =>
        {
            return context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
        });

        app.Run();
    }

    private static IServiceCollection ConfigureSwagger(IServiceCollection services)
    {
        services.AddGrpcSwagger();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo { Title = "gRPC transcoding", Version = "v1" });

            string filePath = Path.Combine(System.AppContext.BaseDirectory, "MangaPlanetto.Cms.Api.xml");
            c.IncludeXmlComments(filePath);
            c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
        });

        return services;
    }
}