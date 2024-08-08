using MangaPlanetto.Cms.Domain.Repositories;
using MangaPlanetto.Cms.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MangaPlanetto.Cms.Infrastructure;
public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMangaRepository, MangaRepository>();

        return services;
    }
}
