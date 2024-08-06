using MediatR;

namespace MangaPlanetto.Cms.Application.CommandQuery.Abstractions;

public interface IQuery : IRequest
{
}

public interface IQuery<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface IQueryHandler<TQuery> : IRequestHandler<TQuery>
    where TQuery : IQuery
{
}

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}

