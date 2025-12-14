using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Data
{
    public class BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : DbContext(options)
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
