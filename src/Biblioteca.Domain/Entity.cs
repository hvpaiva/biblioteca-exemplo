namespace Biblioteca.Domain
{
    using System;

    public class Entity : IEntity
    {
        public virtual Guid Id { get; protected set; } = Guid.NewGuid();
    }
}
