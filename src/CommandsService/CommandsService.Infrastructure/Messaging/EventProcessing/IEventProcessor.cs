using System.Threading.Tasks;

namespace CommandsService.Infrastructure.Messaging.EventProcessing
{
    public interface IEventProcessor
    {
        Task ProcessEvent(string message);
    }
}
