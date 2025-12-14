using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Interfaces
{
    public interface ILivroService
    {
        Task<List<Livro>> ListarLivrosAsync();
        Task<Livro> BuscarLivroPorId(Guid id);
        Task AdicionarLivroAsync(Livro livro);
        Task AlterarLivroAsync(Livro livro);
        Task DeletarLivroAsync(Livro livro);
    }
}
