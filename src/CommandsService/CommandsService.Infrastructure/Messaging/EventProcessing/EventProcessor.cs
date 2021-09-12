using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CommandsService.Infrastructure.Messaging.Models;
using CommandsService.Infrastructure.Services;
using CommandsService.Persistence.Models;
using System.Threading;

namespace CommandsService.Infrastructure.Messaging.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);
        }

        private async Task AddPlatform(string platformPublishedMessage)
        {
            using var scope = _scopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IPlatformService>();
            var platformPublishModel = JsonSerializer.Deserialize<PlatformPublishModel>(platformPublishedMessage);

            try
            {
                var platform = new Platform()
                {
                    Name = platformPublishModel.Name,
                    ExternalId = platformPublishModel.Id
                };

                if (!(await repository.ExternalPlatformExist(platform.ExternalId, CancellationToken.None)))
                {
                    // TODO: Create platform
                }
            }
            catch
            {
                // TODO: ...
            }
        }

        private EventType DetermineEvent(string notification)
        {
            var genericEventModel = JsonSerializer.Deserialize<GenericEventModel>(notification);
            return ToEnum(genericEventModel.Event);
        }

        private EventType ToEnum(string value)
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
    