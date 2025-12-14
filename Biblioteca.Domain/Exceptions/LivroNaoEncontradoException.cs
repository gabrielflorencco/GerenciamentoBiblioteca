namespace Biblioteca.Domain.Exceptions
{
    public class LivroNaoEncontradoException : Exception
    {
        public LivroNaoEncontradoException() : base("Livro não encontrado") { }
    }
}
