using System;
using RabbitMQ.Client;
using System.Threading.Tasks;
using System.Text;

namespace MessageProducer
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                const string queueName = "TestMessageQueue";
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    RequestedConnectionTimeout = TimeSpan.FromMilliseconds(3000)
                };

                using var rabbitConnection = connectionFactory.CreateConnection();
                using var channel = rabbitConnection.CreateModel();

                // Declaring a queue is idempotent 
                channel.QueueDeclare(
                    queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                while (true)
                {
                    var message = $"A nice random message: {DateTime.Now.Ticks}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: queueName,
                        basicProperties: null,
                        body: body);

                    Console.WriteLine(" [x] Sent {0}", message);
                    await Task.Delay(500);
                }
            }
            catch(Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Press [enter] to exit");
            Console.Read();
        }
    }
}