using Biblioteca.Domain.Enums;
using System.Text.RegularExpressions;

namespace Biblioteca.Domain.Entities
{
    public class Pessoa
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public List<Emprestimo> Emprestimos { get; private set; } = new();
        protected Pessoa() { }

        public Pessoa(string nome, string email)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));

            ValidarNome(nome);
            ValidarEmail(email);
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
                throw new ArgumentException("Nome deve ter pelo menos 2 caracteres.");
        }

        private static void ValidarEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            if (!emailRegex.IsMatch(email))
                throw new ArgumentException("Formato de email inválido.");
        }

        public void AdicionarEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos.Add(emprestimo);
        }

        public int QuantidadeEmprestimosAtivos() => Emprestimos.Count(e => e.Status == StatusEmprestimo.Ativo);
    }
}
