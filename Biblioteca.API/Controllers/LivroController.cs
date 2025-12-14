using AutoMapper;
using Biblioteca.API.DTOs;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController(ILivroService livroService, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await livroService.ListarLivrosAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var livro = await livroService.BuscarLivroPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LivroCreateDTO dto)
        {
            var livro = mapper.Map<Livro>(dto);
            await livroService.AdicionarLivroAsync(livro);

            var response = mapper.Map<LivroResponseDTO>(livro);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LivroUpdateDTO dto)
        {
            var livroExistente = await livroService.BuscarLivroPorId(id);

            if (livroExistente is null)
                return NotFound();

            mapper.Map(dto, livroExistente);

            await livroService.AlterarLivroAsync(livroExistente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var livro = await livroService.BuscarLivroPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            await livroService.DeletarLivroAsync(livro);
            return NoContent();
        }
    }
}
