public interface IGreeterHandler
{
    Task<string> GetGreetingAsync(CancellationToken cancellationToken = default);
}