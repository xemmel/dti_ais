using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s => 
        s
        .AddScoped<IGreeterHandler,AngryGreetingHandler>()
        .AddScoped<ISpeakService,SpeakWithTimeStampService>()
        )
    .Build();

host.Run();
