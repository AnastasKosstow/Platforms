using Microsoft.Extensions.Options;
using PlatformService.Messaging.Configuration;
using PlatformService.Messaging.Models;
using RabbitMQ.Client;

namespace PlatformService.Messaging
{
    public class MessageBusClient : IMessageBusClient
    {
        private IConnection _connection;
        private IModel _channel;

        public MessageBusClient(IOptions<RabbitMqConfiguration> rabbitMq)
        {
            var rabbitMqConfiguration = rabbitMq.Value;

            var factory = new ConnectionFactory
            {
                HostName = rabbitMqConfiguration.RabbitMqHost,
                Port = int.Parse(rabbitMqConfiguration.RabbitMqPort)
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(
                exchange: "trigger",
                type: ExchangeType.Fanout);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }
            

        public void Publish(PlatformPublishModel platformPublishModel)
        {
            
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            // TODO: Shutdown Log or msg
        }
    }
}
