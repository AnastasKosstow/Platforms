
namespace PlatformService.Persistence.Repositories
{
    public abstract class BaseAsyncRepository<TEntity>
        where TEntity : class
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        protected BaseAsyncRepository(ApplicationDbContext applicationDbContext)
            =>
            ApplicationDbContext = applicationDbContext;
    }
}
