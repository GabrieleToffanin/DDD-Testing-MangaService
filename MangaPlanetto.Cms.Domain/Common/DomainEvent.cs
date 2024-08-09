using MediatR;

namespace MangaPlanetto.Cms.Domain.Common;

public record class DomainEvent : INotification
{
    public Guid Id { get; init; }
    public DateTime OccurredOn { get; init; }
    //Workaround for EF, generally CosmosClient has no problem with abstract classes
    //Used for Event Sourcing
    //As EFCORE as far as my understeanding of it goes, does not support hierarchycal mapping 
    // of concrete classes, so we need to use a workaround
    public string Body { get; init; }
    public string EventType { get; init; }
}
