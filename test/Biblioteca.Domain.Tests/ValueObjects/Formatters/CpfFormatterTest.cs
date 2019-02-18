using System;
using Biblioteca.Domain.ValueObjects.Formatters;
using Xunit;

namespace Biblioteca.Domain.Tests.ValueObjects.Formatters
{
    public class BaseFormatterTest
    {
        private const string CpfFormatado = "114.582.016-60";
        private const string CpfDesformatado = "11458201660";

        [Fact]
        public void Should_Format_Formatted_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act
            var valorFormatado = cpfFormatter.Format(CpfFormatado);

            // Assert
            Assert.Equal(CpfFormatado, valorFormatado);
        }

        [Fact]
        public void Should_Format_Unformatted_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act
            var valorFormatado = cpfFormatter.Format(CpfDesformatado);

            // Assert
            Assert.Equal(CpfFormatado, valorFormatado);
        }

        [Fact]
        public void Should_Formatted_Value_Be_False_In_IsNotFormatted()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Arrange
            Assert.False(cpfFormatter.IsNotFormatted(CpfFormatado));
        }

        [Fact]
        public void Should_Formatted_Value_Be_True_In_IsFormatted()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Arrange
            Assert.True(cpfFormatter.IsFormatted(CpfFormatado));
        }

        [Fact]
        public void Should_Not_Format_Empty_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.Format("")
            );
        }

        [Fact]
        public void Should_Not_Format_Null_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.Format(null)
            );
        }

        [Fact]
        public void Should_Not_Test_IsFormatted_Of_Empty_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.IsFormatted("")
            );
        }

        [Fact]
        public void Should_Not_Test_IsFormatted_Of_Null_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.IsFormatted(null)
            );
        }

        [Fact]
        public void Should_Not_Test_IsNotFormatted_Of_Empty_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.IsNotFormatted("")
            );
        }

        [Fact]
        public void Should_Not_Test_IsNotFormatted_Of_Null_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.IsNotFormatted(null)
            );
        }

        [Fact]
        public void Should_Not_Unformat_Empty_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.Unformat("")
            );
        }

        [Fact]
        public void Should_Not_Unformat_Null_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Assert
            Assert.ThrowsAny<ArgumentException>(
                () => cpfFormatter.Unformat(null)
            );
        }

        [Fact]
        public void Should_Unformat_Formatted_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act
            var valorDesformatado = cpfFormatter.Unformat(CpfFormatado);

            // Assert
            Assert.Equal(CpfDesformatado, valorDesformatado);
        }

        [Fact]
        public void Should_Unformat_Unformatted_Value()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act
            var valorDesformatado = cpfFormatter.Unformat(CpfDesformatado);

            // Assert
            Assert.Equal(CpfDesformatado, valorDesformatado);
        }

        [Fact]
        public void Should_Unformatted_Value_Be_False_In_IsFormatted()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Arrange
            Assert.False(cpfFormatter.IsFormatted(CpfDesformatado));
        }

        [Fact]
        public void Should_Unformatted_Value_Be_True_In_IsNotFormatted()
        {
            // Arrange
            var cpfFormatter = new CpfFormatter();

            // Act e Arrange
            Assert.True(cpfFormatter.IsNotFormatted(CpfDesformatado));
        }
    }
}