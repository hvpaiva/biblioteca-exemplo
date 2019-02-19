using System;

namespace Biblioteca.Domain
{
    /// <summary>
    ///     Interface de entidade do DDD.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///     Identificador da entidade.
        /// </summary>
        Guid Id { get; }
    }
}