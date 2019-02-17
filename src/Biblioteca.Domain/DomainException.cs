namespace Biblioteca.Domain
{
    public class DomainException : BibliotecaException
    {
        public string BusinessMessage { get; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
