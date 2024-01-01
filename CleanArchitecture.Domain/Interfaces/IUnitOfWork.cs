namespace CleanArchitecture.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit(CancellationToken cancellationToken);
    }
}