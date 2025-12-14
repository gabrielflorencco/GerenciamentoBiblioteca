using Biblioteca.Domain.RepositoriesInterfaces;

namespace Biblioteca.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BibliotecaDbContext _context;

        public UnitOfWork(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
