public class SpeakWithTimeStampService : ISpeakService
{
    public string Speak(string inputText)
    {
        return $"{DateTime.Now}\t{inputText}";
    }
}