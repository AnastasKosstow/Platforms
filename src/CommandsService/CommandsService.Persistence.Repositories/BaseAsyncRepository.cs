using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Persistence.Repositories
{
    public abstract class BaseAsyncRepository<TEntity> : IBaseAsyncRepository<TEntity>, IDisposable
        where TEntity : class
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        protected BaseAsyncRepository(ApplicationDbContext applicationDbContext)
            =>
            ApplicationDbContext = applicationDbContext;


        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await ApplicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
