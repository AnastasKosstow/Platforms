using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Repositories
{
    public interface IBaseAsyncRepository<out TEntity> : IDisposable
    {
        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
