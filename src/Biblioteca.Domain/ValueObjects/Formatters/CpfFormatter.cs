using System.Text.RegularExpressions;
using Biblioteca.Domain.Tests.ValueObjects.Formats;

namespace Biblioteca.Domain.ValueObjects.Formatters
{
    /// <summary>
    ///     Formatador de CPF.
    ///     Formata e Desformata uma string para os padrões de CPF.
    /// </summary>
    public class CpfFormatter : BaseFormatter
    {
        /// <summary>
        ///     Construtor de CpfFormatter. Injeta os valores de formatação.
        /// </summary>
        /// <inheritdoc cref="BaseFormatter" />
        public CpfFormatter()
            : base(
                new Regex(CpfFormat.CpfFormatted, RegexOptions.Compiled | RegexOptions.IgnoreCase),
                new Regex(CpfFormat.CpfUnformatted, RegexOptions.Compiled | RegexOptions.IgnoreCase),
                "$1.$2.$3-$4",
                "$1$2$3$4"
            )
        {
        }
    }
}