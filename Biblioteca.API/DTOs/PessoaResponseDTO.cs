using Biblioteca.Domain.Entities;

namespace Biblioteca.API.DTOs
{
    public class PessoaResponseDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
