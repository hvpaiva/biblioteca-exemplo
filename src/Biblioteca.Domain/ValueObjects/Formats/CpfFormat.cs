namespace Biblioteca.Domain.Tests.ValueObjects.Formats
{
    /// <summary>
    ///     Formatos de CPF.
    /// </summary>
    public class CpfFormat
    {
        /// <summary>
        ///     CPF formatado.
        ///     <example>114.582.016-60</example>
        /// </summary>
        public static string CpfFormatted => @"(\d{3})[.](\d{3})[.](\d{3})-(\d{2})";

        /// <summary>
        ///     CPF desformatado
        ///     <example>11458201660</example>
        /// </summary>
        public static string CpfUnformatted => @"(\d{3})(\d{3})(\d{3})(\d{2})";
    }
}