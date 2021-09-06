using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Persistence.Repositories
{
    public class AsyncRepository<TEntity> : BaseAsyncRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : class
    {
        public AsyncRepository(ApplicationDbContext applicationDbContext)
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


        public virtual bool Remove(TEntity entity)
        {
            var context = ApplicationDbContext
                .Set<TEntity>()
                .Remove(entity);

            return context.State == EntityState.Deleted;
        }


        public virtual TEntity Add(TEntity entity)
        {
            ApplicationDbContext
                .Set<TEntity>()
                .Add(entity);

            return entity;
        }
    }
}
