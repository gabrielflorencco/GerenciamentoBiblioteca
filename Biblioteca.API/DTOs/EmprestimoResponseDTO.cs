using Biblioteca.Domain.Enums;

namespace Biblioteca.API.DTOs
{
    public class EmprestimoResponseDTO
    {
        public Guid Id { get; set; }
        public Guid LivroId { get; set; }
        public Guid PessoaId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataLimite { get; set; }
        public StatusEmprestimo Status { get; set; }
    }
}
