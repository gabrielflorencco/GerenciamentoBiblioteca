using Biblioteca.Application.DependencyInjection;
using Biblioteca.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Biblioteca.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Biblioteca API",
                    Version = "v1",
                    Description = "API para gerenciamento de livros e usuários"
                });

                // ==== Documentação XML para comentários ====
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);

                // ==== Config JWT (se for usar depois) ====
                /*
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Informe o token no formato: Bearer {seu token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                */
            });

            // ------------------- Injecao de Dependencia -------------------

            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddInfrastructureServices(connectionString);
            builder.Services.AddApplicationServices();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API v1");
                c.RoutePrefix = "swagger";

            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
