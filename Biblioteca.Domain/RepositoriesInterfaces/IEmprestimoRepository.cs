using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.RepositoriesInterfaces
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        Task<List<Emprestimo>> ListarPorPessoaIdAsync(Guid pessoaId);
    }
}
