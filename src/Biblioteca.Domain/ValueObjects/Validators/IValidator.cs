using System.Collections.Generic;

namespace Biblioteca.Domain.ValueObjects.Validators
{
    /// <summary>
    ///     Interface de validators de um Value Object.
    /// </summary>
    /// <typeparam name="T">O tipo base do Value Object.</typeparam>
    public interface IValidator<in T>
    {
        /// <summary>
        ///     Confere se o valor é válido, lançando uma exceção caso não seja.
        /// </summary>
        /// <param name="valor">O valor a se checar.</param>
        /// <exception cref="ValueObjectException">Caso o Value Object seja inválido.</exception>
        void AssertValid(T valor);

        /// <summary>
        ///     Checa se o Value Object é válido.
        /// </summary>
        /// <param name="valor">O valor a se checar.</param>
        /// <returns><code>true</code> se for válido e <code>false</code> senão.</returns>
        bool IsValid(T valor);

        /// <summary>
        ///     Devolve uma lista de erros daquele valor.
        /// </summary>
        /// <param name="valor">O valor a se checar.</param>
        /// <returns>Lista de erros.</returns>
        List<string> GetInvalidMessage(T valor);
    }
}