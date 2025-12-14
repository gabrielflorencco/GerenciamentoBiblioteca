using AutoMapper;
using Biblioteca.API.DTOs;
using Biblioteca.Domain.Entities;

namespace Biblioteca.API.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            // De DTO para Entidade (criação e update)
            CreateMap<LivroCreateDTO, Livro>();

            CreateMap<LivroUpdateDTO, Livro>();

            // De Entidade para DTO (response)

            CreateMap<Livro, LivroResponseDTO>();
        }
    }
}
