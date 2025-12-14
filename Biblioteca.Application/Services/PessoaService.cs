using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.RepositoriesInterfaces;

namespace Biblioteca.Application.Services
{
    public class PessoaService(IPessoaRepository pessoaRepository) : IPessoaService
    {
        public async Task AdicionarPessoaAsync(Pessoa pessoa)
        {
            await pessoaRepository.AdicionarAsync(pessoa);
        }

        public async Task AlterarPessoaAsync(Pessoa pessoa)
        {
            await pessoaRepository.AlterarAsync(pessoa);
        }

        public async Task<Pessoa> BuscarPessoaPorId(Guid id)
        {
            var pessoa = await pessoaRepository.BuscarPorIdAsync(id);
            return pessoa == null ? null : pessoa;
        }

        public async Task DeletarPessoaAsync(Pessoa pessoa)
        {
            await pessoaRepository.DeletarAsync(pessoa);
        }

        public async Task<List<Pessoa>> ListarPessoasAsync()
        {
            var pessoas = await pessoaRepository.ListarTodosAsync();
            return pessoas;
        }
    }
}
