using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Infrastructure.Services
{
    public interface IBaseService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);

        Task<TEntity> GetSingle(int id, CancellationToken cancellationToken);

        TEntity Create(TEntity entity);
    }
}
