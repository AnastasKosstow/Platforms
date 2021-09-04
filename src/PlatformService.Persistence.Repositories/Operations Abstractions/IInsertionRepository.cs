
namespace PlatformService.Persistence.Repositories.Abstractions
{
    public interface IInsertionRepository<TEntity>
    {
        TEntity Add(TEntity entity);
    }
}
