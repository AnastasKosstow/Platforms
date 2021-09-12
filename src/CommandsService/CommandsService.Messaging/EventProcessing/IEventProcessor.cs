using System.Threading.Tasks;

namespace CommandsService.Messaging.EventProcessing
{
    public interface IEventProcessor
    {
        Task ProcessEvent();
    }
}
