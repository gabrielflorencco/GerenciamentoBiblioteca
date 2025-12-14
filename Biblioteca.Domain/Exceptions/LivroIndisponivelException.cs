namespace Biblioteca.Domain.Exceptions
{
    public class LivroIndisponivelException : Exception
    {
        public LivroIndisponivelException() : base("Livro Indispónível") { }
    }
}
