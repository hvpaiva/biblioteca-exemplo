namespace Biblioteca.Domain.ValueObjects.Validators.Errors
{
    /// <summary>
    ///     Tipos de erro de CPF.
    /// </summary>
    public static class CpfError
    {
        /// <summary>
        ///     Formatação inválida.
        ///     <example>114.582.01660</example>
        /// </summary>
        public const string InvalidFormat = "Formato inválido.";

        /// <summary>
        ///     CPF nulo ou vazio.
        /// </summary>
        public const string NullOrEmpty = "Cpf nulo ou vazio.";

        /// <summary>
        ///     CPF com os dígitos repetidos.
        ///     <example>000.000.000-00</example>
        /// </summary>
        public const string AllRepeatedDigits = "Todos os dígitos são os mesmos.";

        /// <summary>
        ///     CPF com os dígitos verificadores inválidos.
        ///     <example>114.582.016-65, no qual o correto seria 114.582.016-60</example>
        /// </summary>
        public const string InvalidCheckDigits = "Dígito verificador inválido.";
    }
}