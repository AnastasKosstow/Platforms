using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PlatformService.Application.Models;

namespace PlatformService.Infrastructure.Services
{
    public interface IPlatformService
    {
        Task<IEnumerable<GetPlatformsSuccessModel>> GetAll(CancellationToken cancellationToken);
    }
}
