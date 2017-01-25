namespace Read.Domain
{
    public interface IAggregateRoot<T> : IAggregateRoot
    {
        T Id { get; }
    }
    public interface IAggregateRoot
    {
    }
}
