namespace Biblioteca.Domain
{
    public class DomainException : BibliotecaException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
