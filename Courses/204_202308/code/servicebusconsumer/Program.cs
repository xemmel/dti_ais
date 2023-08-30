// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");


string serviceBusNamespace = "the204sbnamespace";
string topicName = "codedemo";
string subscription = args[0];

var credential = new AzureCliCredential();

ServiceBusClient client = new ServiceBusClient(
        fullyQualifiedNamespace: $"{serviceBusNamespace}.servicebus.windows.net",
        credential: credential);

var receiver = client.CreateReceiver(
    topicName: topicName, subscriptionName: subscription,
    options: new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });
await foreach (var message in receiver.ReceiveMessagesAsync())
{
    var messageString = message.Body.ToString();
    System.Console.WriteLine(messageString);
}

