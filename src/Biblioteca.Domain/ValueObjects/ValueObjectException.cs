using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.ValueObjects
{
    /// <inheritdoc />
    /// <summary>
    ///     Exceção base de Value Object.
    /// </summary>
    public class ValueObjectException : Exception
    {
        /// <inheritdoc />
        /// <summary>
        ///     Construtor de exceção com lista de string como parâmetro.
        /// </summary>
        /// <param name="messages">Lista de mensagens de erro.</param>
        internal ValueObjectException(IEnumerable<string> messages) : base(FormatMessages(messages))
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Construtor da exceção com string de mensagem.
        /// </summary>
        /// <param name="message">A mensagem de erro.</param>
        internal ValueObjectException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Formata a lista de mensagem de erro para uma única string.
        /// </summary>
        /// <param name="messages">Lista de mensagem de erro.</param>
        /// <returns>Uma string de erro separada pelo '\n -'</returns>
        private static string FormatMessages(IEnumerable<string> messages)
        {
            return string.Join("\n -", messages);
        }
    }
}