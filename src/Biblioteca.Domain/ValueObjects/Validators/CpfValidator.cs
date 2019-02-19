using System.Collections.Generic;
using System.Linq;
using Biblioteca.Domain.ValueObjects.Formatters;
using Biblioteca.Domain.ValueObjects.Validators.Errors;

namespace Biblioteca.Domain.ValueObjects.Validators
{
    /// <inheritdoc />
    /// <summary>
    ///     Validator de CPF.
    /// </summary>
    public class CpfValidator : IValidator<string>
    {
        /// <summary>
        ///     O formatador de CPF.
        /// </summary>
        private readonly CpfFormatter _formatter;

        /// <summary>
        ///     Construtor padrão. Injeta o CpfFormatter.
        ///     <seealso cref="CpfFormatter" />
        /// </summary>
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

        /// <summary>
        ///     Confere se o CPF tem um formato válido.
        /// </summary>
        /// <param name="cpf">O CPF a se validar.</param>
        /// <param name="formatter">O formatador de CPF.</param>
        /// <returns><code>true</code> se o CPF for válido, ou <code>false</code> se o CPF for inválido</returns>
        private static bool HasValidFormat(string cpf, IFormatter<string> formatter)
        {
            return formatter.IsFormatted(cpf) || formatter.IsNotFormatted(cpf);
        }

        /// <summary>
        ///     Retorna o CPF sem os dígitos verificadores.
        /// </summary>
        /// <param name="cpf">O CPF.</param>
        /// <param name="formatter">O formatador de CPF.</param>
        /// <returns>O CPF sem os dígitos verificadores.</returns>
        private static string SemDigitosVerificadores(string cpf, IFormatter<string> formatter)
        {
            var cpfDesformatado = formatter.Unformat(cpf);

            return cpfDesformatado.Substring(0, cpfDesformatado.Length - 2);
        }

        /// <summary>
        ///     Valida se o CPF é igual ao CPF calculado.
        /// </summary>
        /// <param name="cpf">O CPF a se checar.</param>
        /// <param name="cpfSemDigitoVerificador">O CPF sem seus dígitos.</param>
        /// <param name="digitoUm">O primeiro dígito verificador.</param>
        /// <param name="digitoDois">O segundo dígito verificador.</param>
        /// <param name="formatter">O Formatador de CPF.</param>
        /// <returns>
        ///     <code>true</code> se o CPF testado for válido, isto é,
        ///     igual ao calculado, ou <code>false</code> senão.
        /// </returns>
        private static bool ValidDigitCheck(string cpf, string cpfSemDigitoVerificador, int digitoUm, int digitoDois,
            IFormatter<string> formatter)
        {
            return formatter.Unformat(cpf) == cpfSemDigitoVerificador + digitoUm + digitoDois;
        }

        /// <summary>
        ///     Confere se o CPF possui todos os dígitos iguais.
        /// </summary>
        /// <param name="cpf">O CPF a se conferir.</param>
        /// <param name="formatter">O formatador de CPF.</param>
        /// <returns>
        ///     <code>true</code> se o CPF possuir todos os dígitos iguais e
        ///     <code>false</code> senão.
        /// </returns>
        private static bool HasAllRepeatedDigits(string cpf, IFormatter<string> formatter)
        {
            var cpfDesformatado = formatter.Unformat(cpf);

            return cpfDesformatado.ToCharArray().Distinct().Count() == 1;
        }

        /// <summary>
        ///     Busca o dígito verificador de um CPF sem dígitos.
        /// </summary>
        /// <param name="cpfSemDigitoVerificador">O CPF sem o dígito verificador.</param>
        /// <returns>O dígito verificador.</returns>
        private static int GetDigitoVerificador(string cpfSemDigitoVerificador)
        {
            var digitos = GetDigitos(cpfSemDigitoVerificador);
            var subtraction =
                GetComplementoDoModuloDe11(GetSomaDosProdutos(cpfSemDigitoVerificador, digitos,
                    GetMultiplicadores(digitos)));

            return subtraction > 9 ? 0 : subtraction;
        }

        /// <summary>
        ///     Retorna uma lista de inteiro com os dígitos de uma string.
        /// </summary>
        /// <param name="strDigits">A string a ser convertida em lista de inteiro.</param>
        /// <returns>Lista de inteiros de dada string.</returns>
        private static int[] GetDigitos(string strDigits)
        {
            return strDigits
                .ToCharArray()
                .Select(c => int.Parse(c.ToString()))
                .ToArray();
        }

        /// <summary>
        ///     Retorna o complementar do módulo de 11.
        /// </summary>
        /// <param name="soma">O número a se tirar o complementar do módulo de onze.</param>
        /// <returns>O complementar do módulo de onze.</returns>
        private static int GetComplementoDoModuloDe11(int soma)
        {
            return 11 - soma % 11;
        }

        /// <summary>
        ///     Retorna a soma dos produto dos dígitos e seus multiplicadores.
        /// </summary>
        /// <param name="cpfSemDigitoVerificador">O CPF sem os dígitos.</param>
        /// <param name="digitos">Lista de dígitos.</param>
        /// <param name="multiplicadores">Os multiplicadores.</param>
        /// <returns>A soma do produto.</returns>
        private static int GetSomaDosProdutos(string cpfSemDigitoVerificador, IReadOnlyList<int> digitos,
            IReadOnlyList<int> multiplicadores)
        {
            var soma = 0;
            for (var i = 0; i < cpfSemDigitoVerificador.Length; i++) soma += digitos[i] * multiplicadores[i];

            return soma;
        }

        /// <summary>
        ///     Retorna a lista de multiplicadores.
        /// </summary>
        /// <param name="digitos">Os dígitos.</param>
        /// <returns>A lista de multiplicadores.</returns>
        private static int[] GetMultiplicadores(IReadOnlyCollection<int> digitos)
        {
            return digitos.Count == 9
                ? new[] {10, 9, 8, 7, 6, 5, 4, 3, 2}
                : new[] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
        }
    }
}