using AmazingBeer.Cerveja.Domain.CQRS;
using AmazingBeer.Cerveja.Domain.Interface.CQRS;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmazingBeer.Cerveja.Infrastructure.CQRS
{
    public class RabbitMQueue : IQueue
    {
        public string Dequeue(string queueName)
        {
            string message = String.Empty;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    message = Encoding.UTF8.GetString(body);
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);
                return message;
            }
        }

        public Task<string> DequeueAsync(string queueName)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(QueueMessage message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: message.QueueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish(exchange: "",
                                    routingKey: message.QueueName,
                                    basicProperties: null,
                                    body: body);

            }
        }

        public Task EnqueueAsync(QueueMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
