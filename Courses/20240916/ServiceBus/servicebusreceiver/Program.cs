// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Messaging.ServiceBus;





string sbNamespace = "mlcais";
string queueName = "mytopic";


string subscriptionName = "subscription1";


//var credential = new DefaultAzureCredential();
var credential = new AzureCliCredential();
var client = new ServiceBusClient(fullyQualifiedNamespace: $"{sbNamespace}.servicebus.windows.net",credential: credential);

var options = new ServiceBusReceiverOptions()
{
    ReceiveMode = ServiceBusReceiveMode.PeekLock
};
var receiver = client.CreateReceiver(queueName,subscriptionName,options);

var messages = await receiver.ReceiveMessagesAsync(maxMessages: 10,maxWaitTime: new TimeSpan(0,0,30));
foreach(var message in messages)
{
    System.Console.WriteLine(message.Body.ToString());
}