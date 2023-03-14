using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s => s
                .AddScoped<IGreeter, HappyGreeter>()
                .AddScoped<ITeknoLogger, ConsoleTeknoLogger>()
    )
    .Build();

host.Run();
