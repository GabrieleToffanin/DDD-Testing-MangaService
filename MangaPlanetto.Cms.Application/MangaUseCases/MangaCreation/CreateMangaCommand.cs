using MangaPlanetto.Cms.Application.CommandQuery.Abstractions;
using MangaPlanetto.Cms.Domain.Entities.Mangas;

namespace MangaPlanetto.Cms.Application.MangaUseCases.MangaCreation;

public record CreateMangaCommand(string title, string currency, decimal value) : ICommand<MangaId>;
