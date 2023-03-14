namespace funcisolated;

public class HappyGreeter : IGreeter
{
    private readonly ITeknoLogger _teknoLogger;

    public HappyGreeter(ITeknoLogger teknoLogger)
    {
        _teknoLogger = teknoLogger;
    }
    public async Task<string> GetGreetingAsync()
    {
        _teknoLogger.LogText("Some nice guy called me!");
        return "Have a great day!";
    }
}
