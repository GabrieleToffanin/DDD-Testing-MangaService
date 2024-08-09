namespace MangaPlanetto.Cms.Domain.Common;


public abstract class Entity
{
    private List<DomainEvent> _domainEvents = new List<DomainEvent>();

    public IEnumerable<DomainEvent> DomainEvents => this._domainEvents;

    protected void AddDomainEvent<TEvent>(TEvent domainEvent)
        where TEvent : DomainEvent
    {
        this._domainEvents.Add(domainEvent);
    }

    protected void RemoveDomainEvent(DomainEvent domainEvent)
    {
        this._domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        this._domainEvents.Clear();
    }

}
