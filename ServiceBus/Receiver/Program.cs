using Azure.Identity;
using Azure.Messaging.ServiceBus;

var credential = new AzureCliCredential();
var serviceBusName = "teknoservicebus01";
var client = new ServiceBusClient(
    fullyQualifiedNamespace: $"{serviceBusName}.servicebus.windows.net",
    credential: credential);


var receiver = client.CreateReceiver(
    topicName: "mytopic",
    subscriptionName: "allmessagesfromdenmark",
    options: new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });
var messages = await receiver.ReceiveMessagesAsync(10, maxWaitTime: new TimeSpan(0, 0, 40));
foreach (var message in messages)
{
    var messageBody = message.Body.ToString();
    System.Console.WriteLine($"Message received: {messageBody}");
}


