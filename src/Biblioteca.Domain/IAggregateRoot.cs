namespace Biblioteca.Domain
{
    /// <summary>
    ///     Classe base para o Aggregate Root, seguindo o modelo DDD.
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        /// <summary>
        ///     Número da versão do Aggregate Root.
        /// </summary>
        int Version { get; }
    }
}