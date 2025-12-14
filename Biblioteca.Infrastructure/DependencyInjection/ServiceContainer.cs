using Biblioteca.Domain.RepositoriesInterfaces;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<BibliotecaDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositorios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Repositorio generico
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();


            return services;
        }
    }
}
