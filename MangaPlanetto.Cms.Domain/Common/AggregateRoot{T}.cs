namespace MangaPlanetto.Cms.Domain.Common;

public abstract class AggregateRoot<TIdentifier> :
    IEquatable<AggregateRoot<TIdentifier>>
    where TIdentifier : notnull, IEquatable<TIdentifier>
{
    protected AggregateRoot(TIdentifier identifier)
    {
        this.Id = identifier;
    }

    public TIdentifier Id { get; protected set; }

    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public IEnumerable<IDomainEvent> DomainEvents => this._domainEvents;

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        this._domainEvents.Add(domainEvent);
    }

    protected void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        this._domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        this._domainEvents.Clear();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
            return false;

        AggregateRoot<TIdentifier> other = (AggregateRoot<TIdentifier>)obj;
        return this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.Id!.GetHashCode();
    }

    public bool Equals(AggregateRoot<TIdentifier>? other)
    {
        if (other is null)
            return false;

        return this.Id!.Equals(other.Id);
    }
}
