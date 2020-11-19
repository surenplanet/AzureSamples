using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace sbtopicsender
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://salesteamapp235445.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=v6UMP0ts/3qDLft0t2wra1jSQgEm+J3SLZN2LfiWJ8M=";

        const string TopicName = "salesperformancemessages";
        static ITopicClient topicClient;

        static void Main(string[] args)
        {

            Console.WriteLine("Sending a message to the Sales Performance topic...");

            SendPerformanceMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine("Message was sent successfully.");

        }

        static async Task SendPerformanceMessageAsync()
        {
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            // Send messages.
            try
            {
                string messageBody = $"Total sales for Brazil in August: $13m.";
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                Console.WriteLine($"Sending message: {messageBody}");
                await topicClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

            await topicClient.CloseAsync();
        }
    }
}
