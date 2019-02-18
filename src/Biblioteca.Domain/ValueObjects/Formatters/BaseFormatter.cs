using System;
using System.Text.RegularExpressions;

namespace Biblioteca.Domain.ValueObjects.Formatters
{
    /// <summary>
    ///     Formatador base de string.
    ///     Recebe pelo construtor os padrões de formatação.
    /// </summary>
    public abstract class BaseFormatter : IFormatter<string>
    {
        private readonly Regex _formatted;
        private readonly string _formattedReplacement;
        private readonly Regex _unformatted;
        private readonly string _unformattedReplacement;

        /// <summary>
        ///     Injeta as dependências dos formatadores concretos.
        /// </summary>
        /// <param name="formatted">O Regex com o padrão formatado.</param>
        /// <param name="unformatted">O Regex com o padrão desformatado.</param>
        /// <param name="formattedReplacement">Modelo para replacement formatado.</param>
        /// <param name="unformattedReplacement">Modelo para replacement desformatado.</param>
        protected BaseFormatter(Regex formatted, Regex unformatted, string formattedReplacement,
            string unformattedReplacement)
        {
            _formatted = formatted;
            _unformatted = unformatted;
            _formattedReplacement = formattedReplacement;
            _unformattedReplacement = unformattedReplacement;
        }

        /// <inheritdoc />
        public virtual string Format(string valor)
        {
            if (string.IsNullOrEmpty(valor)) throw new ArgumentException(nameof(valor));

            return IsFormatted(valor) ? valor : _unformatted.Replace(valor, _formattedReplacement);
        }

        /// <inheritdoc />
        public virtual string Unformat(string valor)
        {
            if (string.IsNullOrEmpty(valor)) throw new ArgumentException(nameof(valor));

            return IsNotFormatted(valor) ? valor : _formatted.Replace(valor, _unformattedReplacement);
        }

        /// <inheritdoc />
        public virtual bool IsFormatted(string valor)
        {
            if (string.IsNullOrEmpty(valor)) throw new ArgumentException(nameof(valor));

            return _formatted.IsMatch(valor);
        }

        /// <inheritdoc />
        public virtual bool IsNotFormatted(string valor)
        {
            if (string.IsNullOrEmpty(valor)) throw new ArgumentException(nameof(valor));

            return _unformatted.IsMatch(valor);
        }
    }
}