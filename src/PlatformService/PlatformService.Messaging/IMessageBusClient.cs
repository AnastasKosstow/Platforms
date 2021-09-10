using PlatformService.Messaging.Models;

namespace PlatformService.Messaging
{
    public interface IMessageBusClient
    {
        void Publish(PlatformPublishModel platformPublishModel);
    }
}
