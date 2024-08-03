using MediatR;

namespace MangaPlanetto.Cms.Domain.Common;

public interface IDomainEvent : INotification
{
    public Guid Id { get; }
    public DateTime OccurredOn { get; }
}
