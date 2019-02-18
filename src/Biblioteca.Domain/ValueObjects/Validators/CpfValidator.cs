using System.Collections.Generic;
using System.Linq;
using Biblioteca.Domain.ValueObjects.Formatters;
using Biblioteca.Domain.ValueObjects.Validators.Errors;

namespace Biblioteca.Domain.ValueObjects.Validators
{
    public class CpfValidator : IValidator<string>
    {
        private readonly CpfFormatter _formatter;

        public CpfValidator()
        {
            _formatter = new CpfFormatter();
        }

        /// <inheritdoc />
        public void AssertValid(string valor)
        {
            if (!IsValid(valor)) throw new ValueObjectException(GetInvalidMessage(valor));
        }

        /// <inheritdoc />
        public bool IsValid(string valor)
        {
            return !GetInvalidMessage(valor).Any();
        }

        /// <inheritdoc />
        public List<string> GetInvalidMessage(string cpf)
        {
            var erros = new List<string>();

            if (!string.IsNullOrEmpty(cpf))
            {
                if (!HasValidFormat(cpf, _formatter))
                {
                    erros.Add(CpfError.InvalidFormat);
                }
                else
                {
                    if (!HasAllRepeatedDigits(cpf, _formatter))
                    {
                        var cpfSemDigitoVerificador = SemDigitosVerificadores(cpf, _formatter);
                        var digito1 = GetDigitoVerificador(cpfSemDigitoVerificador);
                        var digito2 = GetDigitoVerificador(cpfSemDigitoVerificador + digito1);

                        if (!ValidDigitCheck(cpf, cpfSemDigitoVerificador, digito1, digito2, _formatter))
                            erros.Add(CpfError.InvalidCheckDigits);
                    }
                    else
                    {
                        erros.Add(CpfError.AllRepeatedDigits);
                    }
                }
            }
            else
            {
                erros.Add(CpfError.NullOrEmpty);
            }

            return erros;
        }

        //
        // - Cálculos internos

        private static bool HasValidFormat(string cpf, IFormatter<string> formatter)
        {
            return formatter.IsFormatted(cpf) || formatter.IsNotFormatted(cpf);
        }

        private static string SemDigitosVerificadores(string cpf, IFormatter<string> formatter)
        {
            var cpfDesformatado = formatter.Unformat(cpf);

            return cpfDesformatado.Substring(0, cpfDesformatado.Length - 2);
        }

        private static bool ValidDigitCheck(string cpf, string cpfSemDigitoVerificador, int digitoUm, int digitoDois,
            IFormatter<string> formatter)
        {
            return formatter.Unformat(cpf) == cpfSemDigitoVerificador + digitoUm + digitoDois;
        }

        private static bool HasAllRepeatedDigits(string cpf, IFormatter<string> formatter)
        {
            var cpfDesformatado = formatter.Unformat(cpf);

            return cpfDesformatado.ToCharArray().Distinct().Count() == 1;
        }

        private static int GetDigitoVerificador(string cpfSemDigitoVerificador)
        {
            var digitos = GetDigitos(cpfSemDigitoVerificador);
            var subtraction =
                GetComplementoDoModuloDe11(GetSomaDosProdutos(cpfSemDigitoVerificador, digitos,
                    GetMultiplicadores(digitos)));

            return subtraction > 9 ? 0 : subtraction;
        }

        private static int[] GetDigitos(string cpfSemDigitoVerificador)
        {
            return cpfSemDigitoVerificador
                .ToCharArray()
                .Select(c => int.Parse(c.ToString()))
                .ToArray();
        }

        private static int GetComplementoDoModuloDe11(int soma)
        {
            return 11 - soma % 11;
        }

        private static int GetSomaDosProdutos(string cpfSemDigitoVerificador, IReadOnlyList<int> digitos,
            IReadOnlyList<int> multiplicadores)
        {
            var soma = 0;
            for (var i = 0; i < cpfSemDigitoVerificador.Length; i++) soma += digitos[i] * multiplicadores[i];

            return soma;
        }

        private static int[] GetMultiplicadores(IReadOnlyCollection<int> digitos)
        {
            return digitos.Count == 9
                ? new[] {10, 9, 8, 7, 6, 5, 4, 3, 2}
                : new[] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
        }
    }
}