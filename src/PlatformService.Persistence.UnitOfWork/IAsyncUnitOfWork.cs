using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.UnitOfWork
{
    public interface IAsyncUnitOfWork<TContext>
        where TContext : ApplicationDbContext
    {
        Task<int> CompleteAsync(CancellationToken token);
    }
}
