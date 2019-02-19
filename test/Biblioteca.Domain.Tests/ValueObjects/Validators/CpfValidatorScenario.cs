using System.Collections.Generic;
using Biblioteca.Domain.ValueObjects;
using Biblioteca.Domain.ValueObjects.Validators;
using FluentAssertions;
using Xbehave;

namespace Biblioteca.Domain.Tests.ValueObjects.Validators
{
    /// <summary>
    ///     Cenários de teste para o Validator de CPF <see cref="CpfValidator" />:
    ///     [Cenário 1]: Dado um CPF válido e um validator de CPF, quando testo se o CPF
    ///     é válido, o resultado deve ser verdadeiro.
    ///     [Cenário 2]: Dado um CPF inválido e um validator de CPF, quando testo se o CPF
    ///     é válido, o resultado deve ser falso.
    ///     [Cenário 3]: Dado um CPF válido e o validator de CPF, quando valido se o CPF
    ///     é válido, não pode lançar uma exceção.
    ///     [Cenário 4]: Dado um CPF inválido e o validator de CPF, quando valido se o CPF
    ///     é válido, deve lançar exceção com a sua mensagem.
    ///     [Cenário 5]: Dado um CPF inválido e o validator de CPF, buscar mensagens
    ///     de erro desse CPF, que devem ser como esperado.
    ///     [Cenário 6]: Dado um CPF válido e o validator de CPF, buscar mensagens
    ///     de erro desse CPF, que deve ser vazia.
    /// </summary>
    public class CpfValidatorScenario
    {
        // Cenário 1:
        // Dado um CPF válido e um validator de CPF, quando testo se o CPF
        // é válido, o resultado deve ser verdadeiro.
        [Scenario]
        [Example("114.582.016-60")]
        [Example("11458201660")]
        public void Valid_Cpf_In_IsValid(string cpf, IValidator<string> validator, bool isValid)
        {
            $"Dado um CPF válido: {cpf}"
                .Do(() => { });

            "E o validator de CPF,"
                .Do(() => validator = new CpfValidator());

            "Quando testo se o CPF é válido,"
                .Do(() => isValid = validator.IsValid(cpf));

            "O resultado deve ser verdadeiro."
                .Do(() => isValid.Should().BeTrue());
        }

        // Cenário 2:
        // Dado um CPF inválido e um validator de CPF, quando testo se o CPF
        // é válido, o resultado deve ser falso.
        [Scenario]
        [Example("114.582.016-65")]
        [Example("11458201665")]
        [Example("")]
        [Example(null)]
        public void Invalid_Cpf_In_IsValid(string cpf, IValidator<string> validator, bool isValid)
        {
            $"Dado o CPF inválido: {cpf}"
                .Do(() => { });

            "E o validator de CPF,"
                .Do(() => validator = new CpfValidator());

            "Quando testo se o CPF é válido,"
                .Do(() => isValid = validator.IsValid(cpf));

            "O resultado deve ser falso."
                .Do(() => isValid.Should().BeFalse());
        }

        // Cenário 3:
        // Dado um CPF válido e o validator de CPF, quando valido se o CPF
        // é válido, não pode lançar uma exceção.
        [Scenario]
        [Example("114.582.016-60")]
        [Example("11458201660")]
        public void Valid_Cpf_In_AssertValid(string cpf, IValidator<string> validator)
        {
            $"Dado um CPF válido: {cpf}"
                .Do(() => { });

            "E o validator de CPF,"
                .Do(() => validator = new CpfValidator());

            "Quando valido se o CPF é válido, não pode lançar exceção."
                .Do(() => validator.Invoking(v => v.AssertValid(cpf))
                    .Should()
                    .NotThrow<ValueObjectException>());
        }

        // Cenário 4:
        // Dado um CPF inválido e o validator de CPF, quando valido se o CPF
        // é válido, deve lançar exceção com a sua mensagem.
        [Scenario]
        [Example("114.582.016-65", "Dígito verificador inválido.")]
        [Example("11458201665", "Dígito verificador inválido.")]
        [Example("", "Cpf nulo ou vazio.")]
        [Example(null, "Cpf nulo ou vazio.")]
        [Example("000.000.000-00", "Todos os dígitos são os mesmos.")]
        [Example("00000000000", "Todos os dígitos são os mesmos.")]
        [Example("000000000", "Formato inválido.")]
        [Example("100000000000", "Formato inválido.")]
        public void Invalid_Cpf_In_AssertValid(string cpf, string message, IValidator<string> validator)
        {
            $"Dado um CPF inválido: {cpf}"
                .Do(() => { });

            "E o validator de CPF,"
                .Do(() => validator = new CpfValidator());

            $"Quando valido se o CPF é válido, deve lançar exceção com a seguinte mensagem: {message}."
                .Do(() => validator.Invoking(val => val.AssertValid(cpf))
                    .Should()
                    .Throw<ValueObjectException>()
                    .WithMessage(message));
        }

        // Cenário 5:
        // Dado um CPF inválido e o validator de CPF, buscar mensagens
        // de erro desse CPF, que devem ser como esperado.
        [Scenario]
        [Example("114.582.016-61", new[] {"Dígito verificador inválido."})]
        [Example("114.582.01660", new[] {"Formato inválido."})]
        [Example("", new[] {"Cpf nulo ou vazio."})]
        [Example(null, new[] {"Cpf nulo ou vazio."})]
        [Example("00000000000", new[] {"Todos os dígitos são os mesmos."})]
        public void Error_Messages_In_GetInvalidMessages_With_Invalid_Cpf(string cpf,
            string[] expectedMessage, IValidator<string> validator, List<string> messages)
        {
            $"Dado um CPF inválido: {cpf}"
                .Do(() => { });

            "E o validator de CPF"
                .Do(() => validator = new CpfValidator());

            "Buscar mensagens de erro desse CPF"
                .Do(() => messages = validator.GetInvalidMessage(cpf));

            $"Que devem ser: {expectedMessage}."
                .Do(() => messages.Should().Equal(expectedMessage));
        }

        // Cenário 6:
        // Dado um CPF válido e o validator de CPF, buscar mensagens
        // de erro desse CPF, que deve ser vazia.
        [Scenario]
        [Example("114.582.016-60")]
        [Example("11458201660")]
        public void Error_Messages_In_GetInvalidMessages_With_Valid_Cpf(string cpf, IValidator<string> validator,
            List<string> messages)
        {
            $"Dado um CPF válido: {cpf}"
                .Do(() => { });

            "E o validator de CPF"
                .Do(() => validator = new CpfValidator());

            "Buscar mensagens de erro desse CPF"
                .Do(() => messages = validator.GetInvalidMessage(cpf));

            "Que deve ser vazia."
                .Do(() => messages.Should().BeEmpty());
        }
    }
}