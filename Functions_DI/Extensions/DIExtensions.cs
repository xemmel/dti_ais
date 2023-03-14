using Microsoft.Extensions.DependencyInjection;

namespace funcisolated;

public static class DIExtensions
{
    public static string GreetIt(this string input)
    {
        return $"Hello {input}";
    }

    public static IServiceCollection AddFuncIsolatedServices(this IServiceCollection services)
    {
        services
            .AddScoped<IGreeter, HappyGreeter>()
            .AddScoped<ITeknoLogger, ConsoleTeknoLogger>();
        return services;
    }
}