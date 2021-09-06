using PlatformService.Persistence.Models;
using System.Threading.Tasks;

namespace PlatformService.Messaging
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(Platform platform);
    }
}
