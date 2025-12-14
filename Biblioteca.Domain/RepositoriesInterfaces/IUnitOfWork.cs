namespace Biblioteca.Domain.RepositoriesInterfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
