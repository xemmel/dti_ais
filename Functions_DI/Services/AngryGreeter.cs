namespace funcisolated;

public class AngryGreeter : IGreeter
{
    private readonly ITeknoLogger _teknoLogger;

    public AngryGreeter(ITeknoLogger teknoLogger)
    {
        _teknoLogger = teknoLogger;
    }
    public async Task<string> GetGreetingAsync()
    {
        _teknoLogger.LogText("Some idiot called me!");
        return "Have a bad day!";
    }
}
