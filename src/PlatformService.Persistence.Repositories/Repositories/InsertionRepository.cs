using PlatformService.Persistence.Repositories.Abstractions;

namespace PlatformService.Persistence.Repositories.Repositories
{
    public class InsertionRepository<TEntity> : BaseAsyncRepository<TEntity>, IInsertionRepository<TEntity>
        where TEntity : class
    {
        public InsertionRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
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
