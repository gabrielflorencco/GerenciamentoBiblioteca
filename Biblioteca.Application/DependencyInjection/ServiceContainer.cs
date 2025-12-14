using Biblioteca.Application.Interfaces;
using Biblioteca.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registre aqui seus serviços de aplicação
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();

            // Se usar validações:
            // services.AddScoped<IValidator<LivroDto>, LivroValidator>();

            // Se usar MediatR:
            // services.AddMediatR(typeof(ServiceContainer).Assembly);

            return services;
        }
    }
}
