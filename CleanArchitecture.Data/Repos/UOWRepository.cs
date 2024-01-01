using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Data.Repos
{
    public class UOWRepository : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private bool disposedValue;

        public UOWRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit(CancellationToken cancellationToken) => await _dbContext.SaveChangesAsync(cancellationToken);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~UOWRepository()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
