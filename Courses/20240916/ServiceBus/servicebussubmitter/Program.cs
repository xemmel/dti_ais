// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

string sbNamespace = "mlcais";
string queueName = "mytopic";

string countryCode = args[0];
int count = int.Parse(args[1]);


//var credential = new DefaultAzureCredential();
var credential = new AzureCliCredential();

var client = new ServiceBusClient(fullyQualifiedNamespace: $"{sbNamespace}.servicebus.windows.net", credential: credential);

var sender = client.CreateSender(queueName);
for (int i = 1; i <= count; i++)
{
    var message = new ServiceBusMessage($"Message {i}");
    message.ApplicationProperties.Add("erplocation", countryCode);
    await sender.SendMessageAsync(message);
    System.Console.WriteLine($"Message {i} sent....");
}



//Write Blob to Storage Account

