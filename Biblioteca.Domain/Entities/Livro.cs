using Biblioteca.Domain.Exceptions;

namespace Biblioteca.Domain.Entities
{
    public class Livro
    {
        public Guid Id { get; private set; }
        public string ISBN { get; private set; }
        public string Titulo { get; private set; } = string.Empty;
        public string Autor { get; private set; } = string.Empty;
        public int AnoPublicacao { get; private set; }
        public bool EstaDisponivel { get; private set; } = true;

        protected Livro() { }

        public Livro(string titulo, string autor, string isbn, int anoPublicacao, bool estaDisponivel)
        {
            ISBN = isbn ?? throw new ArgumentException("ISBN não pode ser nulo.");
            Titulo = titulo ?? throw new ArgumentException("Título não pode ser nulo.");
            Autor = autor ?? throw new ArgumentException("Autor não pode ser nulo.");
            AnoPublicacao = anoPublicacao;
            EstaDisponivel = estaDisponivel;

            ValidarISBN(ISBN);
            ValidarAnoPublicacao(AnoPublicacao);
        }

        public void MarcarComoIndisponivel()
        {
            EstaDisponivel = false;
        }

        public void MarcarComoDisponivel()
        {
            EstaDisponivel = true;
        }

        private void ValidarISBN(string isbn)
        {
            string isbnLimpo = isbn.Replace("-", "");
            if (!isbnLimpo.All(char.IsDigit) || (isbnLimpo.Length != 10 && isbnLimpo.Length != 13))
            {
                throw new ISBNInvalidoException();
            }
        }

        private void ValidarAnoPublicacao(int ano)
        {
            if (ano < 1800 || ano > DateTime.Now.Year)
                throw new LivroIndisponivelException();
        }
    }
}
