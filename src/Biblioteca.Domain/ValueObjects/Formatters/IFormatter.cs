using System;

namespace Biblioteca.Domain.ValueObjects.Formatters
{
    /// <summary>
    ///     Interface de formatação de um Value Object
    /// </summary>
    /// <typeparam name="T">Tipo primitivo de um Value Object</typeparam>
    public interface IFormatter<T>
    {
        /// <summary>
        ///     Formata um value object.
        /// </summary>
        /// <param name="valor">O valor a se formatar.</param>
        /// <returns>O valor formatado.</returns>
        /// <exception cref="ArgumentException">Se o valor for <code>null</code> ou vazio.</exception>
        T Format(T valor);

        /// <summary>
        ///     Desformata um value object.
        /// </summary>
        /// <param name="valor">O valor a se desformatar.</param>
        /// <returns>O valor desformatado.</returns>
        /// <exception cref="ArgumentException">Se o valor for <code>null</code> ou vazio.</exception>
        T Unformat(T valor);

        /// <summary>
        ///     Verifica se o valor está conforme o formatador trabalha, mas formatado.
        /// </summary>
        /// <param name="valor">O valor a se checar.</param>
        /// <returns><code>true</code> se estiver no formato formatado.</returns>
        /// <exception cref="ArgumentException">Se o valor for <code>null</code> ou vazio.</exception>
        bool IsFormatted(T valor);

        /// <summary>
        ///     Verifica se o valor está conforme o formatador trabalha, mas desformatado.
        /// </summary>
        /// <param name="valor">O valor a se checar.</param>
        /// <returns><code>true</code> se estiver no formato desformatado.</returns>
        /// <exception cref="ArgumentException">Se o valor for <code>null</code> ou vazio.</exception>
        bool IsNotFormatted(T valor);
    }
}