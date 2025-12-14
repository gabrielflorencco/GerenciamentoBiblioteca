using Biblioteca.Domain.Entities;
using Biblioteca.Domain.RepositoriesInterfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IRepository<Pessoa> _repositoryBase;
        public PessoaRepository(IRepository<Pessoa> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<Pessoa> AdicionarAsync(Pessoa pessoa)
        {
            await _repositoryBase.AdicionarAsync(pessoa);
            return pessoa;
        }

        public async Task<Pessoa> AlterarAsync(Pessoa pessoa)
        {
            await _repositoryBase.AlterarAsync(pessoa);
            return pessoa;
        }

        public async Task<Pessoa> BuscarPorIdAsync(Guid id)
        {
            return await _repositoryBase.BuscarPorIdAsync(id);
        }

        public async Task DeletarAsync(Pessoa entity)
        {
            await _repositoryBase.DeletarAsync(entity);
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _repositoryBase.ExisteAsync(id);
        }

        public async Task<List<Pessoa>> ListarTodosAsync()
        {
            return await _repositoryBase.ListarTodosAsync();
        }
    }
}
