using Biblioteca.Domain.Enums;

namespace Biblioteca.Domain.Entities
{
    public class Emprestimo
    {
        public Guid Id { get; private set; }
        public Guid LivroId { get; private set; }
        public Guid PessoaId { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataLimite { get; private set; }
        public StatusEmprestimo Status { get; private set; }

        public Emprestimo(Guid pessoaId, Guid livroId)
        {
            PessoaId = pessoaId;
            LivroId = livroId;
            DataEmprestimo = DateTime.Now;
            DataLimite = DataEmprestimo.AddDays(14);
            Status = StatusEmprestimo.Ativo;
        }

        public void Devolver()
        {
            if (Status != StatusEmprestimo.Ativo)
                throw new InvalidOperationException("Empréstimo já foi devolvido.");

            DataDevolucao = DateTime.Now;
            Status = StatusEmprestimo.Devolvido;
        }

        public bool EstaAtrasado() => Status == StatusEmprestimo.Ativo && DateTime.Now > DataLimite;
    }
}