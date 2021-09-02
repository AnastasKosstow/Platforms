using Microsoft.EntityFrameworkCore;
using PlatformService.Persistence.Repositories.Abstractions;

namespace PlatformService.Persistence.Repositories.Repositories
{
    public class DeletionRepository<TEntity> : BaseAsyncRepository<TEntity>, IDeletionRepository<TEntity>
        where TEntity : class
    {
        public DeletionRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public virtual bool Remove(TEntity entity)
        {
            var context = ApplicationDbContext
                .Set<TEntity>()
                .Remove(entity);

            return context.State == EntityState.Deleted;
        }
    }
}
