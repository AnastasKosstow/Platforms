using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PlatformService.Messaging.Configuration;
using PlatformService.Messaging.Models;
using RabbitMQ.Client;

namespace PlatformService.Messaging
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly RabbitMqConfiguration _rabbitMq;

        public MessageBusClient(
            IConfiguration configuration,
            IOptions<RabbitMqConfiguration> rabbitMq)
        {
            _configuration = configuration;
            _rabbitMq = rabbitMq.Value;
        }


        public void Publish(PlatformPublishModel platformPublishModel)
        {
            var factory = new ConnectionFactory
            {
                HostName = _rabbitMq.RabbitMqHost
            };

            throw new NotImplementedException();
        }
    }
}
