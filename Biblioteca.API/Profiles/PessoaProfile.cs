using AutoMapper;
using Biblioteca.API.DTOs;
using Biblioteca.Domain.Entities;

namespace Biblioteca.API.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            // Entrada
            CreateMap<PessoaCreateDTO, Pessoa>();
            CreateMap<PessoaUpdateDTO, Pessoa>();

            // Saída
            CreateMap<Pessoa, PessoaResponseDTO>();
        }
    }
}
