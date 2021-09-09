using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CommandsService.Persistence.Abstractions;
using CommandsService.Persistence.Repositories;

namespace CommandsService.Infrastructure.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : IPersistenceModel
    {
        private readonly IAsyncRepository<TEntity> _asyncRepository;

        public BaseService(IAsyncRepository<TEntity> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _asyncRepository.GetAll(cancellationToken);
        }

        public async virtual Task<TEntity> GetSingle(int id, CancellationToken cancellationToken)
        {
            // TODO: Guard
            return await _asyncRepository.GetSingle(entity => entity.Id == id, cancellationToken);
        }

        public virtual TEntity Create(TEntity entity)
        {
            // TODO: Guard
            return _asyncRepository.Create(entity);
        }
    }
}
