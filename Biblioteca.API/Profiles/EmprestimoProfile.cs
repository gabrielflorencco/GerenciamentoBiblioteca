using AutoMapper;
using Biblioteca.API.DTOs;
using Biblioteca.Domain.Entities;

namespace Biblioteca.API.Profiles
{
    public class EmprestimoProfile : Profile
    {
        public EmprestimoProfile()
        {
            // De DTO para Entidade (criação e update)
            CreateMap<EmprestimoCreateDTO, Emprestimo>();

            CreateMap<EmprestimoUpdateDTO, Emprestimo>();

            // De Entidade para DTO (response)

            CreateMap<Emprestimo, EmprestimoResponseDTO>();
        }
    }
}
