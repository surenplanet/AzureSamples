using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace sbqueueSender
{
    class Program
    {

        const string ServiceBusConnectionString = "Endpoint=sb://salesteamapp235445.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=v6UMP0ts/3qDLft0t2wra1jSQgEm+J3SLZN2LfiWJ8M=";
        const string QueueName = "salesmessages";
        static IQueueClient queueClient;

        static void Main(string[] args)
        {
            Console.WriteLine("Sending a message to the Sales Messages queue...");

            SendSalesMessageAsync().GetAwaiter().GetResult();

            Console.WriteLine("Message was sent successfully.");
        }

        static async Task SendSalesMessageAsync()
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            // Send messages.
            try
            {
                string messageBody = $"$10,000 order for bicycle parts from retailer Adventure Works.";
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                Console.WriteLine($"Sending message: {messageBody}");
                await queueClient.SendAsync(message);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }

           await queueClient.CloseAsync();
        }
    }
}
