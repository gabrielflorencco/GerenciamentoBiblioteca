using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> ListarPessoasAsync();
        Task<Pessoa> BuscarPessoaPorId(Guid id);
        Task AdicionarPessoaAsync(Pessoa pessoa);
        Task AlterarPessoaAsync(Pessoa pessoa);
        Task DeletarPessoaAsync(Pessoa pessoa);
    }
}
