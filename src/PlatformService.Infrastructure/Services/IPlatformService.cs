using PlatformService.Application.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Services
{
    public interface IPlatformService
    {
        Task<IEnumerable<GetPlatformsSuccessModel>> GetAll(CancellationToken cancellationToken);
    }
}
