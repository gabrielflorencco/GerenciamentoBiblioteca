using AutoMapper;
using Biblioteca.API.DTOs;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController(IEmprestimoService emprestimoService, IPessoaService pessoaService, ILivroService livroService, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emprestimos = await emprestimoService.ListarEmprestimosAsync();
            return Ok(emprestimos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var livro = await emprestimoService.BuscarEmprestimoPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmprestimoCreateDTO dto)
        {
            var emprestimo = mapper.Map<Emprestimo>(dto);
            await emprestimoService.AdicionarEmprestimoAsync(emprestimo);

            var response = mapper.Map<EmprestimoResponseDTO>(emprestimo);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EmprestimoUpdateDTO dto)
        {
            var emprestimoExistente = await emprestimoService.BuscarEmprestimoPorId(id);

            if (emprestimoExistente is null)
                return NotFound();

            mapper.Map(dto, emprestimoExistente);

            await emprestimoService.AlterarEmprestimoAsync(emprestimoExistente);

            return NoContent();
        }

        [HttpPut("{id:guid}/devolver")]
        public async Task<IActionResult> Devolver(Guid id)
        {
            var emprestimo = await emprestimoService.BuscarEmprestimoPorId(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            await emprestimoService.DevolverEmprestimoAsync(id);
            return NoContent();
        }
    }
}
