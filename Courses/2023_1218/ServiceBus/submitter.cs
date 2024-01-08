// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

string serviceBusNamespace = "dgidemo202401";
string queueName = "mytopic";


//DI



//var credential = new DefaultAzureCredential();
var credential = new AzureCliCredential();

var client = new ServiceBusClient(
    fullyQualifiedNamespace: $"{serviceBusNamespace}.servicebus.windows.net",
    credential: credential);

var sender = client.CreateSender(queueOrTopicName: queueName);

var message = new ServiceBusMessage("Hello from .net code");

message.ApplicationProperties.Add("country",args[0]);

await sender.SendMessageAsync(message);
System.Console.WriteLine("Message sent...");



