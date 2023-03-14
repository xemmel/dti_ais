namespace funcisolated;

public class ConsoleTeknoLogger : ITeknoLogger
{
    public void LogText(string text)
    {
        System.Console.WriteLine($"I am logging to the console: {text}");
    }
}