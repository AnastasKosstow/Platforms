using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Repositories.Abstractions
{
    public interface IAsyncReadOnlyRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
    }
}
