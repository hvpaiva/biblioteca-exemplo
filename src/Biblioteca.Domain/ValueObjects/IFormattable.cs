namespace Biblioteca.Domain.ValueObjects
{
    /// <summary>
    ///     Provém uma forma formatada e desformatada de si mesmo.
    /// </summary>
    /// <typeparam name="T">O tipo base daquele Value Object.</typeparam>
    public interface IFormattable<out T>
    {
        /// <summary>
        ///     Retorna a sua representação desformatada.
        /// </summary>
        /// <returns>Sua representação desformatada.</returns>
        T Unformatted();

        /// <summary>
        ///     Retorna a sua representação formatada.
        /// </summary>
        /// <returns>Sua representação formatada.</returns>
        T Formatted();
    }
}