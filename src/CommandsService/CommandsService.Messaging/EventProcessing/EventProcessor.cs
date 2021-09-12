using System.Text.Json;
using System.Threading.Tasks;
using CommandsService.Messaging.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.Messaging.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task ProcessEvent()
        {
            throw new System.NotImplementedException();
        }

        private EventType DetermineEvent(string notification)
        {
            var genericEventModel = JsonSerializer.Deserialize<GenericEventModel>(notification);
            return ToEnum(genericEventModel.Event);
        }

        private EventType ToEnum(this string value)
        {
            EventType defaultValue = EventType.Undetermined;

            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            EventType result;
            return System.Enum.TryParse(value, true, out result) ? result : defaultValue;
        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}
