namespace Biblioteca.Domain
{
    using System;

    public class BibliotecaException : Exception
    {
        public BibliotecaException()
        { }

        public BibliotecaException(string message)
            : base(message)
        { }

        public BibliotecaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
