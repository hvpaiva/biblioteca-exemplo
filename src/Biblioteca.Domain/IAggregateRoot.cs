namespace Biblioteca.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}