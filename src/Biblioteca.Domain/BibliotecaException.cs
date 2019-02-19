using System;

namespace Biblioteca.Domain
{
    /// <inheritdoc />
    /// <summary>
    ///     Exceção base da Solution.
    /// </summary>
    public class BibliotecaException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        ///     Construtor vazio.
        /// </summary>
        protected BibliotecaException()
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Construtor com mensagem de erro.
        /// </summary>
        /// <param name="message"></param>
        public BibliotecaException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Construtor com mensagem de erro e exceção interna.
        /// </summary>
        /// <param name="message">A mensagem de erro.</param>
        /// <param name="innerException">A exceção interna.</param>
        public BibliotecaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}