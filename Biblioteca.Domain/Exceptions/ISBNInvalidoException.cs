namespace Biblioteca.Domain.Exceptions
{
    internal class ISBNInvalidoException : Exception
    {
        public ISBNInvalidoException() : base("ISBN inválido para o livro.") { }
    }
}
