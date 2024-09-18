
public class HappyGreetingHandler : IGreeterHandler
{

    public async Task<string> GetGreetingAsync(CancellationToken cancellationToken = default)
    {
        return "Hello from Function app. Have a nice day";
    }
}