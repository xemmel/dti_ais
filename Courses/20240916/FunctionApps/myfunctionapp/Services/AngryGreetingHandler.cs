
public class AngryGreetingHandler : IGreeterHandler
{
    private readonly ISpeakService _speakService;

    public AngryGreetingHandler(ISpeakService speakService)
    {
        _speakService = speakService;
    }

    public async Task<string> GetGreetingAsync(CancellationToken cancellationToken = default)
    {
        var inputText = "Hello from Function app. Have a rotten day";
        var resultText = _speakService.Speak(inputText);
        return resultText;
    }
}