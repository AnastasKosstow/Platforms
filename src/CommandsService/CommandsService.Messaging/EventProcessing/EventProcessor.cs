using System.Threading.Tasks;

namespace CommandsService.Messaging.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        public Task ProcessEvent()
        {
            throw new System.NotImplementedException();
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}
