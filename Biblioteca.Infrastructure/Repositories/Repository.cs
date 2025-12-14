using Biblioteca.Domain.Entities;
using Biblioteca.Domain.RepositoriesInterfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly BibliotecaDbContext _context;
        protected readonly IUnitOfWork _uow;

        public Repository(BibliotecaDbContext context, IUnitOfWork uow)
        {
            _dbSet = context.Set<T>();
            _context = context;
            _uow = uow;
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _uow.SaveChangesAsync();
            return entity;
        }

        public async Task<T> AlterarAsync(T entity)
        {
            _dbSet.Update(entity);
            await _uow.SaveChangesAsync();
            return entity;
        }

        public async Task<T> BuscarPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task DeletarAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _uow.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public async Task<List<T>> ListarTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
