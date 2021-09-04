using PlatformService.Persistence.Repositories.Abstractions;

namespace PlatformService.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity> :
        IBaseAsyncRepository<TEntity>,
        IAsyncReadOnlyRepository<TEntity>, 
        IDeletionRepository<TEntity>, 
        IInsertionRepository<TEntity>
    {
    }
}
