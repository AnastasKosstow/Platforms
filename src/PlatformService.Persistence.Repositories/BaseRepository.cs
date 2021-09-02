
namespace PlatformService.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly ApplicationDbContext ApplicationDbContext;

        protected BaseRepository(ApplicationDbContext applicationDbContext)
            =>
            ApplicationDbContext = applicationDbContext;
    }
}
