using Biblioteca.Application.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.RepositoriesInterfaces;

namespace Biblioteca.Application.Services
{
    public class EmprestimoService(
        IEmprestimoRepository emprestimoRepository,
        ILivroRepository livroRepository,
        IPessoaRepository pessoaRepository
    ) : IEmprestimoService
    {
        public async Task AdicionarEmprestimoAsync(Emprestimo emprestimo)
        {
            var livro = await livroRepository.BuscarPorIdAsync(emprestimo.LivroId);

            if (livro == null)
                throw new LivroNaoEncontradoException();

            if (!livro.EstaDisponivel)
                throw new LivroIndisponivelException();

            var pessoa = await pessoaRepository.BuscarPorIdAsync(emprestimo.PessoaId);

            if (pessoa == null)
                throw new PessoaNaoEncontradaException();

            // Regras de negócio
            livro.MarcarComoIndisponivel();
            pessoa.AdicionarEmprestimo(emprestimo);

            await emprestimoRepository.AdicionarAsync(emprestimo);
        }

        public async Task AlterarEmprestimoAsync(Emprestimo emprestimo)
        {
            await emprestimoRepository.AlterarAsync(emprestimo);
        }

        public async Task<Emprestimo> BuscarEmprestimoPorId(Guid id)
        {
            var emprestimo = await emprestimoRepository.BuscarPorIdAsync(id);
            return emprestimo == null ? null : emprestimo;
        }

        public async Task DevolverEmprestimoAsync(Guid id)
        {
            var emprestimo = await emprestimoRepository.BuscarPorIdAsync(id);
            var livro = await livroRepository.BuscarPorIdAsync(emprestimo.LivroId);

            emprestimo.Devolver();
            livro.MarcarComoDisponivel();

            await emprestimoRepository.AlterarAsync(emprestimo);
        }

        public async Task<List<Emprestimo>> ListarEmprestimosDaPessoaAsync(Guid pessoaId)
        {
            return await emprestimoRepository.ListarPorPessoaIdAsync(pessoaId);
        }

        public async Task<List<Emprestimo>> ListarEmprestimosAsync()
        {
            var emprestimos = await emprestimoRepository.ListarTodosAsync();
            return emprestimos;
        }
    }
}
