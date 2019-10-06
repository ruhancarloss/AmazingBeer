using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System;
using AmazingBeer.Cerveja.Domain.CQRS.CommandHandlers;
using Newtonsoft.Json;
using AmazingBeer.Cerveja.Domain.CQRS.Commands;
using AmazingBeer.Cerveja.Domain.Services;
using AmazingBeer.Cerveja.Infrastructure.DataAccess.Repositories.EFCore;

namespace AmazingBeer.Cerveja.Console
{
    class Program
    {
        private static CervejaCommandHandler _commandHandler;
        static void Main(string[] args)
        {
            _commandHandler = new CervejaCommandHandler(
                new CervejaService(
                    new CervejaRepository()
                )
            );


            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "create-cerveja-command-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    System.Console.WriteLine(" [x] Received {0}", message);
                    var command = JsonConvert.DeserializeObject<CreateCervejaCommand>(message);
                    _commandHandler.Handle(command);
                };
                channel.BasicConsume(queue: "create-cerveja-command-queue",
                                     autoAck: true,
                                     consumer: consumer);
            }

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "update-cerveja-command-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    System.Console.WriteLine(" [x] Received {0}", message);
                    var command = JsonConvert.DeserializeObject<UpdateCervejaCommand>(message);
                    _commandHandler.Handle(command);
                };
                channel.BasicConsume(queue: "update-cerveja-command-queue",
                                     autoAck: true,
                                     consumer: consumer);

            }

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "delete-cerveja-command-queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    System.Console.WriteLine(" [x] Received {0}", message);
                    var command = JsonConvert.DeserializeObject<DeleteCervejaCommand>(message);
                    _commandHandler.Handle(command);
                };
                channel.BasicConsume(queue: "delete-cerveja-command-queue",
                                     autoAck: true,
                                     consumer: consumer);

                System.Console.WriteLine(" Press [enter] to exit.");
                System.Console.ReadLine();
            }
        }
    }
}
