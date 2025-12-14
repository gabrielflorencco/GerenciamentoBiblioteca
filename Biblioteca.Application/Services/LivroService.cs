using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.RepositoriesInterfaces;

namespace Biblioteca.Application.Services
{
    public class LivroService(ILivroRepository livroRepository) : ILivroService
    {

        public async Task AdicionarLivroAsync(Livro livro)
        {
            await livroRepository.AdicionarAsync(livro);
        }

        public async Task AlterarLivroAsync(Livro livro)
        {
            await livroRepository.AlterarAsync(livro);
        }

        public async Task<Livro> BuscarLivroPorId(Guid id)
        {
            var livro = await livroRepository.BuscarPorIdAsync(id);
            return livro == null ? null : livro;
        }

        public async Task DeletarLivroAsync(Livro livro)
        {
            await livroRepository.DeletarAsync(livro);
        }

        public async Task<List<Livro>> ListarLivrosAsync()
        {
            var livros = await livroRepository.ListarTodosAsync();
            return livros;
        }
    }
}
