using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Biblioteca.Infrastructure.Data
{
    public class BibliotecaDbContextFactory : IDesignTimeDbContextFactory<BibliotecaDbContext>
    {
        public BibliotecaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BibliotecaDbContext>();

            var connectionString =
                "server=localhost;port=3306;database=biblioteca;user=root;password=root";

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString));

            return new BibliotecaDbContext(optionsBuilder.Options);
        }
    }
}