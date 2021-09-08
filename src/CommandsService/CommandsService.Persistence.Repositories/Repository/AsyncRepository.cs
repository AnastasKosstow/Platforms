using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Persistence.Repositories
{
    public class AsyncRepository<TEntity> : BaseAsyncRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : class
    {
        public AsyncRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await ApplicationDbContext
                .Set<TEntity>()
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return await ApplicationDbContext
                .Set<TEntity>()
                .Where(filter)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public virtual TEntity Create(TEntity entity)
        {
            ApplicationDbContext
                .Set<TEntity>()
                .Add(entity);

            return entity;
        }
    }
}
