using CustomerApiWithService.Infra.Persistence.Contexts;
using System;

namespace CustomerApiWithService.Infra.Persistence.Repositories
{
    public abstract class BaseRepositoryAsync : IDisposable
    {
        // Fields
        protected readonly ApplicationDbContext _dbContext;

        // Ctors
        public BaseRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Methods
        public async void Dispose()
        {
            if (_dbContext != null)
                await _dbContext.DisposeAsync();
        }
    }
}
