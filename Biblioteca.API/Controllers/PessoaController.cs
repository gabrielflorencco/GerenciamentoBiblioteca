using AutoMapper;
using Biblioteca.API.DTOs;
using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController(IPessoaService pessoaService, IEmprestimoService emprestimoService, IMapper mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pessoasRaw = await pessoaService.ListarPessoasAsync();
            List<PessoaResponseDTO> pessoasResponse = new List<PessoaResponseDTO>();
            foreach (var pessoa in pessoasRaw)
            {
                pessoasResponse.Add(mapper.Map<PessoaResponseDTO>(pessoa));
            }
            return Ok(pessoasResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pessoa = await pessoaService.BuscarPessoaPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            var response = mapper.Map<PessoaResponseDTO>(pessoa);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PessoaCreateDTO dto)
        {
            var pessoa = mapper.Map<Pessoa>(dto);
            await pessoaService.AdicionarPessoaAsync(pessoa);

            var response = mapper.Map<PessoaResponseDTO>(pessoa);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PessoaUpdateDTO dto)
        {
            var pessoaExistente = await pessoaService.BuscarPessoaPorId(id);

            if (pessoaExistente is null)
                return NotFound();

            mapper.Map(dto, pessoaExistente);

            await pessoaService.AlterarPessoaAsync(pessoaExistente);

            return NoContent();
        }

        [HttpGet("{id}/emprestimos")]
        public async Task<IActionResult> GetEmprestimosDaPessoa(Guid id)
        {
            var emprestimos = await emprestimoService.ListarEmprestimosDaPessoaAsync(id);
            return Ok(emprestimos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var livro = await pessoaService.BuscarPessoaPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            await pessoaService.DeletarPessoaAsync(livro);
            return NoContent();
        }
    }
}
