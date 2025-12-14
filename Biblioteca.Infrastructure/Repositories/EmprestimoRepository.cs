using Biblioteca.Domain.Entities;
using Biblioteca.Domain.RepositoriesInterfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        protected readonly BibliotecaDbContext _context;
        protected readonly IRepository<Emprestimo> _repository;

        public EmprestimoRepository(IRepository<Emprestimo> repository, BibliotecaDbContext context)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<Emprestimo> AdicionarAsync(Emprestimo emprestimo)
        {
            await _repository.AdicionarAsync(emprestimo);
            return emprestimo;
        }

        public async Task<Emprestimo> AlterarAsync(Emprestimo emprestimo)
        {
            await _repository.AlterarAsync(emprestimo);
            return emprestimo;
        }

        public async Task<Emprestimo> BuscarPorIdAsync(Guid id)
        {
            return await _repository.BuscarPorIdAsync(id);
        }

        public async Task DeletarAsync(Emprestimo emprestimo)
        {
            await _repository.DeletarAsync(emprestimo);
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _repository.ExisteAsync(id);
        }

        public async Task<List<Emprestimo>> ListarPorPessoaIdAsync(Guid pessoaId)
        {
            return await _context.Emprestimos
                         .Where(e => e.PessoaId == pessoaId)
                         .ToListAsync();
        }

        public async Task<List<Emprestimo>> ListarTodosAsync()
        {
            return await _repository.ListarTodosAsync();
        }
    }
}
