using System;

namespace Biblioteca.Domain
{
    /// <summary>
    ///     Classe base para entidades, seguindo o modelo DDD.
    /// </summary>
    public class Entity : IEntity
    {
        /// <summary>
        ///     Identificador da entidade.
        /// </summary>
        public virtual Guid Id { get; } = Guid.NewGuid();
    }
}