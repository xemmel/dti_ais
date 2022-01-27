// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Microsoft.Azure.Relay;
using System.Text.Json;

//Console.WriteLine("Hello, World!");

var listener = GetListener();

listener.Connecting += (o, e) => { Console.WriteLine("Connecting.."); };
listener.Online += (o, e) => { Console.WriteLine("Online"); };

listener.RequestHandler = SomebodyCalled;


await listener.OpenAsync();
await Console.In.ReadLineAsync();



static HybridConnectionListener GetListener()
{
    string ns = "teknorelay.servicebus.windows.net";
    string hc = "onprem";

    var listener = new HybridConnectionListener
        (new Uri(String.Format("sb://{0}/{1}", ns, hc)),
        GetTokenProvider());
    return listener;
}


static TokenProvider GetTokenProvider()
{
    string kn = "Listener";
    string k = "qm3a+pRFxEWpNYgzmMgjnw9s+tQ0ezuY/EjuGpuXjKM=";
    var result = TokenProvider.CreateSharedAccessSignatureTokenProvider(kn, k);
    return result;
}

static async void SomebodyCalled(RelayedHttpListenerContext context)
{
    string response = "Hello from on-prem";

    var responseClass = new ResponseClass();
    responseClass.Message = response;
    var json = JsonSerializer
            .Serialize(value: responseClass, options: new JsonSerializerOptions { WriteIndented = true });
    context.Response.Headers.Add("content-type", "application/json");
    using (var sw = new StreamWriter(context.Response.OutputStream))
    {
        await sw.WriteLineAsync(json);
    }

    context.Response.Close();
}