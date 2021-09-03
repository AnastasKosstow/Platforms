using Microsoft.EntityFrameworkCore;
using PlatformService.Persistence.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Persistence.Repositories.Repositories
{
    public class AsyncReadOnlyRepository<TEntity> : BaseAsyncRepository<TEntity>, IAsyncReadOnlyRepository<TEntity>
        where TEntity : class
    {
        public AsyncReadOnlyRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public virtual async Task<IEnumerable<TEntity>> All(CancellationToken cancellationToken)
        {
            return await ApplicationDbContext
                .Set<TEntity>()
                .ToArrayAsync(cancellationToken);
        }

        public virtual async Task<TEntity[]> Find(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await ApplicationDbContext
                .Set<TEntity>()
                .Where(filter)
                .ToArrayAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await ApplicationDbContext
                .Set<TEntity>()
                .Where(filter)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
