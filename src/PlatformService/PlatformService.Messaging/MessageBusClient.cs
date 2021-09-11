using Microsoft.Extensions.Options;
using PlatformService.Messaging.Configuration;
using PlatformService.Messaging.Models;
using RabbitMQ.Client;
using System.Text.Json;

namespace PlatformService.Messaging
{
    public class MessageBusClient : IMessageBusClient
    {
        private IConnection _connection;
        private IModel _channel;

        private readonly RabbitMqConfiguration _rabbitMq;

        public MessageBusClient(IOptions<RabbitMqConfiguration> rabbitMq)
        {
            _rabbitMq = rabbitMq.Value;
        }
            

        public void Publish(PlatformPublishModel platformPublishModel)
        {
            var body = JsonSerializer.SerializeToUtf8Bytes(platformPublishModel);

            var factory = new ConnectionFactory
            {
                HostName = _rabbitMq.RabbitMqHost,
                Port = int.Parse(_rabbitMq.RabbitMqPort)
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            _channel.ExchangeDeclare(
                exchange: "trigger",
                type: ExchangeType.Fanout);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

            channel.QueueDeclare
                (queue: "", 
                exclusive: false, 
                autoDelete: false);

            channel.BasicPublish(
                exchange: "trigger", 
                routingKey: "", 
                basicProperties: null, 
                body: body);
        }


        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            // TODO: Shutdown Log or msg
        }
    }
}
