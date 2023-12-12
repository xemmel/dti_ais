using System.Text.Json;
using Azure.Core;
using Microsoft.Azure.Relay;


var listener = GetListener();
listener.Connecting += (o, e) => { Console.WriteLine("Connecting.."); };
listener.Online += (o, e) => { Console.WriteLine("Online"); };


listener.RequestHandler = SomebodyCalled;

static async void SomebodyCalled(RelayedHttpListenerContext context)
{
    var req = await JsonSerializer
                       .DeserializeAsync<RequestModel>(
                           utf8Json: context.Request.InputStream,
                           options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    Console.WriteLine($"Somebody called, with the following metod: {req!.Method}");
    context.Response.Close();
}

await listener.OpenAsync();

await Console.In.ReadLineAsync();

static HybridConnectionListener GetListener()
{
    string ns = "###.servicebus.windows.net";
    string hc = "###";

    var listener = new HybridConnectionListener
        (new Uri(String.Format("sb://{0}/{1}", ns, hc)),
        GetTokenProvider());
    return listener;
}

static TokenProvider GetTokenProvider()
{
    string kn = "###";
    string k = "###";
    var result = TokenProvider.CreateSharedAccessSignatureTokenProvider(kn, k);
    return result;
}
