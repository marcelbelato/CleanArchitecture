using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data.Repos
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            _dbContext.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            _dbContext.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletedAt = DateTimeOffset.UtcNow;
            _dbContext.Remove(entity);
        }

        public async Task<T> Get(int id, CancellationToken cancellationToken) => await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<List<T>> GetAll(CancellationToken cancellationToken) => await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }
}
