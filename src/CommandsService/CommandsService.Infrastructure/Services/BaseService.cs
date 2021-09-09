using CommandsService.Persistence.Abstractions;
using CommandsService.Persistence.Repositories;

namespace CommandsService.Infrastructure.Services
{
    public abstract class BaseService<TEntity>
        where TEntity : IPersistenceModel
    {
        protected readonly IAsyncRepository<TEntity> _asyncRepository;

        public BaseService(IAsyncRepository<TEntity> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
    }
}
