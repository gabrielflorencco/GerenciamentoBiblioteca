using Biblioteca.Domain.Entities;
using Biblioteca.Domain.RepositoriesInterfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        protected readonly IRepository<Livro> _livroRepository;

        public LivroRepository(IRepository<Livro> livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<Livro> AdicionarAsync(Livro livro)
        {
            await _livroRepository.AdicionarAsync(livro);
            return livro;
        }

        public async Task<Livro> AlterarAsync(Livro livro)
        {
            await _livroRepository.AlterarAsync(livro);
            return livro;
        }

        public async Task<Livro> BuscarPorIdAsync(Guid id)
        {
            return await _livroRepository.BuscarPorIdAsync(id);
        }

        public async Task DeletarAsync(Livro livro)
        {
            await _livroRepository.DeletarAsync(livro);
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _livroRepository.ExisteAsync(id);
        }

        public async Task<List<Livro>> ListarTodosAsync()
        {
            return await _livroRepository.ListarTodosAsync();
        }
    }
}
