
using Azure.Identity;
using Azure.Messaging.ServiceBus;

var credential = new AzureCliCredential();
var serviceBusName = "teknoservicebus01";
var client = new ServiceBusClient(
    fullyQualifiedNamespace : $"{serviceBusName}.servicebus.windows.net",
    credential: credential);
string country = args[0];
var sender = client.CreateSender("mytopic");

var message = new ServiceBusMessage("hello from application");
message.ApplicationProperties["country"] = country;
await sender.SendMessageAsync(message);
System.Console.WriteLine("Message sent...");