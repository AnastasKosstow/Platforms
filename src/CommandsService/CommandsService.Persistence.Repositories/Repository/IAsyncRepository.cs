using CommandsService.Persistence.Repositories.Abstractions;

namespace CommandsService.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity> :
        IBaseAsyncRepository<TEntity>,
        IAsyncReadOnlyRepository<TEntity>,
        IInsertionRepository<TEntity>
    {
    }
}
