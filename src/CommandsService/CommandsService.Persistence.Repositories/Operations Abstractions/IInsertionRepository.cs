
namespace CommandsService.Persistence.Repositories.Abstractions
{
    public interface IInsertionRepository<TEntity>
    {
        TEntity Create(TEntity entity);
    }
}
