namespace Biblioteca.Domain
{
    public abstract class DomainException : BibliotecaException
    {
        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }

        public string BusinessMessage { get; }
    }
}