using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Exceptions;
using Biblioteca.Domain.RepositoriesInterfaces;
using Moq;

namespace Biblioteca.Tests.Emprestimos
{
    public class EmprestimoServiceTests
    {
        [Fact(DisplayName = "Emprestar Livro Indisponível")]
        [Trait("Categoria", "Ações com Empréstimo")]
        public async Task Emprestar_LivroIndisponivel_DeveLancarExcecao()
        {
            // ============ ARRANGE ============
            var idLivro = Guid.NewGuid();
            var idPessoa = Guid.NewGuid();

            var livroIndisponivel = new Livro("Titulo Teste", "Autor Qualquer", "1234567890", 2012, false);

            var livroRepositoryMock = new Mock<ILivroRepository>();
            livroRepositoryMock
                .Setup(r => r.BuscarPorIdAsync(idLivro))
                .ReturnsAsync(livroIndisponivel);

            var emprestimoRepositoryMock = new Mock<IEmprestimoRepository>();
            var pessoaRepositoryMock = new Mock<IPessoaRepository>();
            var uowRepositoryMock = new Mock<IUnitOfWork>();

            var service = new EmprestimoService(
                emprestimoRepositoryMock.Object,
                livroRepositoryMock.Object,
                pessoaRepositoryMock.Object
            );

            var emprestimo = new Emprestimo(idPessoa, idLivro);

            // ============ ACT ============
            var acao = () => service.AdicionarEmprestimoAsync(emprestimo);

            // ============ ASSERT ============
            await Assert.ThrowsAsync<LivroIndisponivelException>(acao);

            // certificar que NÃO tentou registrar o empréstimo
            emprestimoRepositoryMock.Verify(
                r => r.AdicionarAsync(It.Is<Emprestimo>(e =>
                    e.LivroId == idLivro && e.PessoaId == idPessoa)),
                Times.Never
            );
        }

        [Fact(DisplayName = "Devolver Livro Já Devolvido")]
        [Trait("Categoria", "Ações com Empréstimo")]
        public void Devolver_LivroJaDevolvido_DeveLancarExcecao()
        {
            // ============ ARRANGE ============
            var idLivro = Guid.NewGuid();
            var idPessoa = Guid.NewGuid();

            var livroIndisponivel = new Livro("Titulo Teste", "Autor Qualquer", "1234567890", 2012, true);

            var livroRepositoryMock = new Mock<ILivroRepository>();
            livroRepositoryMock
                .Setup(r => r.BuscarPorIdAsync(idLivro))
                .ReturnsAsync(livroIndisponivel);

            var emprestimo = new Emprestimo(idPessoa, idLivro);
            emprestimo.Devolver(); // devolvido antes da ação

            // ============ ACT ============
            var acao = () => emprestimo.Devolver();

            // ============ ASSERT ============
            Assert.Throws<InvalidOperationException>(acao);
        }
    }
}
