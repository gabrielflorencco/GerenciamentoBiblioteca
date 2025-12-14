namespace Biblioteca.API.DTOs
{
    public class EmprestimoCreateDTO
    {
        public Guid LivroId { get; set; }
        public Guid PessoaId { get; set; }
    }
}
