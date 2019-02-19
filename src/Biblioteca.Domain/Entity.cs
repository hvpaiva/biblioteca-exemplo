using System;

namespace Biblioteca.Domain
{
    public class Entity : IEntity
    {
        public virtual Guid Id { get; } = Guid.NewGuid();
    }
}