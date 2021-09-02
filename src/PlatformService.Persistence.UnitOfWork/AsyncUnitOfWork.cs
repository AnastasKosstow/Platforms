using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.UnitOfWork
{
    public class AsyncUnitOfWork<TContext> : IAsyncUnitOfWork<TContext>, IDisposable
        where TContext : ApplicationDbContext
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AsyncUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
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
