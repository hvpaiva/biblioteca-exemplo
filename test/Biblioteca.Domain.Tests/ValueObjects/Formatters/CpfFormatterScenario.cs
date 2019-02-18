using System;
using Biblioteca.Domain.ValueObjects;
using Biblioteca.Domain.ValueObjects.Formatters;
using FluentAssertions;
using Xbehave;

namespace Biblioteca.Domain.Tests.ValueObjects.Formatters
{
    /// <summary>
    ///     Cenários de teste para o formatador de CPF <see cref="CpfFormatter" />:
    ///     [Cenário 1]: Dado um CPF formatado e o formatador de CPF,
    ///     quando usamos o formatador para formatar o CPF, deve vir formatado.
    ///     [Cenário 2]: Dado um CPF desformatado e o formatador de CPF,
    ///     quando usamos o formatador para formatar o CPF, deve vir formatado.
    ///     [Cenário 3]: Dado um CPF formatado e o formatador de CPF,
    ///     quando usamos o formatador para desformatar o CPF, deve vir desformatado.
    ///     [Cenário 4]: Dado um CPF desformatado e o formatador de CPF,
    ///     quando usamos o formatador para desformatar o CPF, deve vir desformatado.
    ///     [Cenário 5]: Dado um CPF nulo ou vazio e o formatador de CPF,
    ///     quando usamos o formatador para formatar o CPF, deve lançar uma exceção.
    ///     [Cenário 6]: Dado um CPF nulo ou vazio e o formatador de CPF,
    ///     quando usamos o formatador para desformatar o CPF, deve lançar uma exceção.
    ///     [Cenário 7]: Dado um CPF nulo ou vazio e o formatador de CPF,
    ///     quando checamos se o CPF está formatado, deve lançar uma exceção.
    ///     [Cenário 8]: Dado um CPF nulo ou vazio e o formatador de CPF,
    ///     quando checamos se o CPF está desformatado, deve lançar uma exceção.
    ///     [Cenário 9]: Dado um CPF formatado e o formatador de CPF,
    ///     quando checamos so o CPF está formatado, deve retornar verdadeiro.
    ///     [Cenário 10]: Dado um CPF formatado e o formatador de CPF,
    ///     quando checamos se o CPF está desformatado, deve retornar falso.
    ///     [Cenário 11]: Dado um CPF desformatado e o formatador de CPF,
    ///     quando checamos se o CPF está formatado, deve retornar falso.
    ///     [Cenário 12]: Dado um CPF desformatado e o formatador de CPF,
    ///     quando checamos se o CPF está desformatado, deve retornar verdadeiro.
    ///     [Cenário 13]: Dado um CPF com formato inválido e o formatador de CPF,
    ///     quando usamos o formatador para formatar o CPF, deve lançar uma exceção.
    ///     [Cenário 14]: Dado um CPF com formato inválido e o formatador de CPF,
    ///     quando usamos o formatador para desformatar o CPF, deve lançar uma exceção.
    ///     [Cenário 15]: Dado um CPF com formato inválido e o formatador de CPF,
    ///     quando checamos se o CPF está formatado, deve retornar falso.
    ///     [Cenário 16]: Dado um CPF com formato inválido e o formatador de CPF,
    ///     quando checamos se o CPF está desformatado, deve retornar falso.
    /// </summary>
    public class CpfFormatterScenario
    {
        // Cenário 1:
        // Dado um CPF formatado e o formatador de CPF,
        // quando usamos o formatador para formatar o CPF, deve vir formatado.
        [Scenario]
        [Example("114.582.016-60", "114.582.016-60")]
        [Example("114.582.016-61", "114.582.016-61")]
        public void Formatted_Cpf_Should_Continue_Formatted_In_Format(string cpf, string expectedCpf,
            string formattedCpf, IFormatter<string> formatter)
        {
            $"Dado um CPF formatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para formatar o CPF"
                .x(() => formattedCpf = formatter.Format(cpf));

            "Deve vir formatado."
                .x(() => formattedCpf.Should().Be(expectedCpf));
        }

        // Cenário 2:
        // Dado um CPF desformatado e o formatador de CPF,
        // quando usamos o formatador para formatar o CPF, deve vir formatado.
        [Scenario]
        [Example("11458201660", "114.582.016-60")]
        [Example("11458201661", "114.582.016-61")]
        public void Unformatted_Cpf_Should_Be_Formatted_In_Format(string cpf, string expectedCpf,
            string formattedCpf, IFormatter<string> formatter)
        {
            $"Dado um CPF desformatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para formatar o CPF"
                .x(() => formattedCpf = formatter.Format(cpf));

            "Deve vir formatado"
                .x(() => formattedCpf.Should().Be(expectedCpf));
        }

        // Cenário 3:
        // Dado um CPF formatado e o formatador de CPF,
        // quando usamos o formatador para desformatar o CPF, deve vir desformatado.
        [Scenario]
        [Example("114.582.016-60", "11458201660")]
        [Example("114.582.016-61", "11458201661")]
        public void Formatted_Cpf_Should_Be_Unformatted_In_Unformat(string cpf, string expectedCpf,
            string unformattedCpf, IFormatter<string> formatter)
        {
            $"Dado um CPF formatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para desformatar o CPF"
                .x(() => unformattedCpf = formatter.Unformat(cpf));

            "Deve vir desformatado"
                .x(() => unformattedCpf.Should().Be(expectedCpf));
        }

        // Cenário 4:
        // Dado um CPF desformatado e o formatador de CPF,
        // quando usamos o formatador para desformatar o CPF, deve vir desformatado.
        [Scenario]
        [Example("11458201660", "11458201660")]
        [Example("11458201661", "11458201661")]
        public void Unformatted_Cpf_Should_Continue_Unformatted_In_Unformat(string cpf,
            string expectedCpf, string unformattedCpf, IFormatter<string> formatter)
        {
            $"Dado um CPF desformatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para desformatar o CPF"
                .x(() => unformattedCpf = formatter.Unformat(cpf));

            "Deve vir desformatado"
                .x(() => unformattedCpf.Should().Be(expectedCpf));
        }

        // Cenário 5:
        // Dado um CPF nulo ou vazio e o formatador de CPF,
        // quando usamos o formatador para formatar o CPF, deve lançar uma exceção.
        [Scenario]
        [Example(null, "Valor não pode ser vazio ou nulo.")]
        [Example("", "Valor não pode ser vazio ou nulo.")]
        public void Null_Or_Empty_Cpf_Should_Throw_Exception_In_Format(string cpf, string message,
            IFormatter<string> formatter)
        {
            $"Dado um CPF null ou vazio: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para formatar o CPF, deve lançar uma exceção."
                .x(() => formatter.Invoking(f => f.Format(cpf))
                    .Should()
                    .Throw<ArgumentException>()
                    .WithMessage(message));
        }

        // Cenário 6:
        // Dado um CPF nulo ou vazio e o formatador de CPF,
        // quando usamos o formatador para desformatar o CPF, deve lançar uma exceção.
        [Scenario]
        [Example(null, "Valor não pode ser vazio ou nulo.")]
        [Example("", "Valor não pode ser vazio ou nulo.")]
        public void Null_Or_Empty_Cpf_Should_Throw_Exception_In_Unformat(string cpf, string message,
            IFormatter<string> formatter)
        {
            $"Dado um CPF null ou vazio: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para desformatar o CPF, deve lançar uma exceção."
                .x(() => formatter.Invoking(f => f.Format(cpf))
                    .Should()
                    .Throw<ArgumentException>()
                    .WithMessage(message));
        }

        // Cenário 7:
        // Dado um CPF nulo ou vazio e o formatador de CPF,
        // quando checamos se o CPF está formatado, deve lançar uma exceção.
        [Scenario]
        [Example(null, "Valor não pode ser vazio ou nulo.")]
        [Example("", "Valor não pode ser vazio ou nulo.")]
        public void Null_Or_Empty_Cpf_Should_Throw_Exception_In_IsFormatted(string cpf, string message,
            IFormatter<string> formatter)
        {
            $"Dado um CPF null ou vazio: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos se o CPF está formatado, deve lançar uma exceção."
                .x(() => formatter.Invoking(f => f.IsFormatted(cpf))
                    .Should()
                    .Throw<ArgumentException>()
                    .WithMessage(message));
        }

        // Cenário 8:
        // Dado um CPF nulo ou vazio e o formatador de CPF,
        // quando checamos se o CPF está desformatado, deve lançar uma exceção.
        [Scenario]
        [Example(null, "Valor não pode ser vazio ou nulo.")]
        [Example("", "Valor não pode ser vazio ou nulo.")]
        public void Null_Or_Empty_Cpf_Should_Throw_Exception_In_IsNotFormatted(string cpf, string message,
            IFormatter<string> formatter)
        {
            $"Dado um CPF null ou vazio: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos se o CPF está desformatado, deve lançar uma exceção."
                .x(() => formatter.Invoking(f => f.IsNotFormatted(cpf))
                    .Should()
                    .Throw<ArgumentException>()
                    .WithMessage(message));
        }

        // Cenário 9:
        // Dado um CPF formatado e o formatador de CPF,
        // quando checamos so o CPF está formatado, deve retornar verdadeiro.
        [Scenario]
        [Example("114.582.016-60")]
        [Example("114.582.016-61")]
        public void Formatted_Cpf_Should_Be_True_In_IsFormatted(string cpf, IFormatter<string> formatter)
        {
            $"Dado um CPF formatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos so o CPF está formatado, deve retornar verdadeiro."
                .x(() => formatter.IsFormatted(cpf).Should().BeTrue());
        }

        // Cenário 10:
        // Dado um CPF formatado e o formatador de CPF,
        // quando checamos se o CPF está desformatado, deve retornar falso.
        [Scenario]
        [Example("114.582.016-60")]
        [Example("114.582.016-61")]
        public void Formatted_Cpf_Should_Be_False_In_IsNotFormatted(string cpf, IFormatter<string> formatter)
        {
            $"Dado um CPF formatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos so o CPF está desformatado, deve retornar falso."
                .x(() => formatter.IsNotFormatted(cpf).Should().BeFalse());
        }

        // Cenário 11:
        // Dado um CPF desformatado e o formatador de CPF,
        // quando checamos se o CPF está formatado, deve retornar falso.
        [Scenario]
        [Example("11458201660")]
        [Example("11458201661")]
        public void Unformatted_Cpf_Should_Be_False_In_IsFormatted(string cpf, IFormatter<string> formatter)
        {
            $"Dado um CPF desformatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos so o CPF está formatado, deve retornar falso."
                .x(() => formatter.IsFormatted(cpf).Should().BeFalse());
        }

        // Cenário 12:
        // Dado um CPF desformatado e o formatador de CPF,
        // quando checamos se o CPF está desformatado, deve retornar verdadeiro.
        [Scenario]
        [Example("11458201660")]
        [Example("11458201661")]
        public void Unformatted_Cpf_Should_Be_True_In_IsNotFormatted(string cpf, IFormatter<string> formatter)
        {
            $"Dado um CPF desformatado: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos so o CPF está desformatado, deve retornar verdadeiro."
                .x(() => formatter.IsNotFormatted(cpf).Should().BeTrue());
        }

        // Cenário 13:
        // Dado um CPF com formato inválido e o formatador de CPF,
        // quando usamos o formatador para formatar o CPF, deve lançar uma exceção.
        [Scenario]
        [Example("000000", "Formato de inválido.")]
        [Example("000000000000", "Formato de inválido.")]
        [Example("000.000.000-000", "Formato de inválido.")]
        [Example("000.000.00000", "Formato de inválido.")]
        public void Invalid_Format_Cpf_Should_Throw_Exception_In_Format(string cpf, string message,
            IFormatter<string> formatter)
        {
            $"Dado um CPF com formato inválido: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para formatar o CPF, deve lançar uma exceção."
                .x(() => formatter.Invoking(f => f.Format(cpf))
                    .Should()
                    .Throw<ValueObjectException>()
                    .WithMessage(message));
        }

        // Cenário 14:
        // Dado um CPF com formato inválido e o formatador de CPF,
        // quando usamos o formatador para desformatar o CPF, deve lançar uma exceção.
        [Scenario]
        [Example("000000", "Formato de inválido.")]
        [Example("000000000000", "Formato de inválido.")]
        [Example("000.000.000-000", "Formato de inválido.")]
        [Example("000.000.00000", "Formato de inválido.")]
        public void Invalid_Format_Cpf_Should_Throw_Exception_In_Unformat(string cpf, string message,
            IFormatter<string> formatter)
        {
            $"Dado um CPF com formato inválido: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando usamos o formatador para formatar o CPF, deve lançar uma exceção."
                .x(() => formatter.Invoking(f => f.Unformat(cpf))
                    .Should()
                    .Throw<ValueObjectException>()
                    .WithMessage(message));
        }

        // Cenário 15:
        // Dado um CPF com formato inválido e o formatador de CPF,
        // quando checamos se o CPF está formatado, deve retornar falso.
        [Scenario]
        [Example("000000")]
        [Example("000000000000")]
        [Example("000.000.000-000")]
        [Example("000.000.00000")]
        public void Invalid_Format_Cpf_Should_Be_False_In_IsFormatted(string cpf, IFormatter<string> formatter)
        {
            $"Dado um CPF com formato inválido: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos se o CPF está formatado, deve retornar falso."
                .x(() => formatter.IsFormatted(cpf).Should().BeFalse());
        }

        // Cenário 16:
        // Dado um CPF com formato inválido e o formatador de CPF,
        // quando checamos se o CPF está desformatado, deve retornar falso.
        [Scenario]
        [Example("000000")]
        [Example("000000000000")]
        [Example("000.000.000-000")]
        [Example("000.000.00000")]
        public void Invalid_Format_Cpf_Should_Be_False_In_IsNotFormatted(string cpf, IFormatter<string> formatter)
        {
            $"Dado um CPF com formato inválido: {cpf}"
                .x(() => { });

            "E o formatador de CPF"
                .x(() => formatter = new CpfFormatter());

            "Quando checamos se o CPF está formatado, deve retornar falso."
                .x(() => formatter.IsNotFormatted(cpf).Should().BeFalse());
        }
    }
}