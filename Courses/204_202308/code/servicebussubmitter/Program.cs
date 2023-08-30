// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

string serviceBusNamespace = "the204sbnamespace";
string topicName = "codedemo";

string country = args[0];

var credential = new AzureCliCredential();

ServiceBusClient client = new ServiceBusClient(
        fullyQualifiedNamespace: $"{serviceBusNamespace}.servicebus.windows.net",
        credential: credential);

var sender = client.CreateSender(topicName);

var message = new ServiceBusMessage("I am a message from a .NET app");
message.ApplicationProperties.Add("country",country);

await sender.SendMessageAsync(message);


System.Console.WriteLine("Message sent");

