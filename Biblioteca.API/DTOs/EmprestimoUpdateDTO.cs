using Biblioteca.Domain.Enums;

namespace Biblioteca.API.DTOs
{
    public class EmprestimoUpdateDTO
    {
        public Guid LivroId { get; set; }
        public Guid PessoaId { get; set; }
        public DateTime DataDevolucao { get; set; }
        public StatusEmprestimo Status { get; set; }
    }
}
