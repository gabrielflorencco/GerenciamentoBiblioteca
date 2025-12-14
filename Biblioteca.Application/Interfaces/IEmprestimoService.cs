using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<List<Emprestimo>> ListarEmprestimosAsync();
        Task<Emprestimo> BuscarEmprestimoPorId(Guid id);
        Task AdicionarEmprestimoAsync(Emprestimo emprestimo);
        Task AlterarEmprestimoAsync(Emprestimo emprestimo);
        Task<List<Emprestimo>> ListarEmprestimosDaPessoaAsync(Guid pessoaId);
        Task DevolverEmprestimoAsync(Guid id);
    }
}
