
namespace PlatformService.Persistence.Repositories.Abstractions
{
    public interface IDeletionRepository<TEntity>
    {
        bool Remove(TEntity entity);
    }
}
