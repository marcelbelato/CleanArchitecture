using CleanArchitecture.Data.Context;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data.Repos
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }

        public Task<User> GetByEmail(string email, CancellationToken cancellationToken) => _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}
