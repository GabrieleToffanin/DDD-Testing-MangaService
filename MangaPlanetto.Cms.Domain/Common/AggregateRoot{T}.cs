namespace MangaPlanetto.Cms.Domain.Common;

public abstract class AggregateRoot<TIdentifier> : Entity, IEquatable<AggregateRoot<TIdentifier>>
    where TIdentifier : notnull, IEquatable<TIdentifier>
{
    protected AggregateRoot(TIdentifier identifier)
    {
        this.Id = identifier;
    }

    public TIdentifier Id { get; protected set; }

    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
            return false;

        AggregateRoot<TIdentifier> other = obj as AggregateRoot<TIdentifier>;
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
