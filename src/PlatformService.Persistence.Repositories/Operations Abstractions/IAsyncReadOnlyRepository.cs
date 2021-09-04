using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Repositories.Abstractions
{
    public interface IAsyncReadOnlyRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> All(CancellationToken cancellationToken);

        Task<TEntity[]> Find(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);

        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
    }
}
