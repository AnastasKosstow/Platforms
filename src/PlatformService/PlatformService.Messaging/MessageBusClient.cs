using Microsoft.Extensions.Options;
using PlatformService.Messaging.Configuration;
using PlatformService.Messaging.Models;
using RabbitMQ.Client;

namespace PlatformService.Messaging
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly RabbitMqConfiguration _rabbitMq;

        public MessageBusClient(IOptions<RabbitMqConfiguration> rabbitMq)
            =>
            _rabbitMq = rabbitMq.Value;

        public void Publish(PlatformPublishModel platformPublishModel)
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitMq.RabbitMqHost,
                Port = int.Parse(_rabbitMq.RabbitMqPort)
            };


        }
    }
}
