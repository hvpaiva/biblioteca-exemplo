namespace Biblioteca.Domain.ValueObjects.Validators.Errors
{
    public class CpfError
    {
        public const string InvalidFormat = "Formato inválido.";
        public const string NullOrEmpty = "Cpf nulo ou vazio.";
        public const string AllRepeatedDigits = "Todos os dígitos são os mesmos.";
        public const string InvalidCheckDigits = "Dígito verificador inválido.";
    }
}