using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace funcisolated
{
    public class Greeter
    {
        private readonly ILogger _logger;
        private readonly IGreeter _greeter;

        public Greeter(ILoggerFactory loggerFactory, IGreeter greeter)
        {
            _logger = loggerFactory.CreateLogger<Greeter>();
            _greeter = greeter;
        }

        [Function("Greeter")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            //var greeter = new AngryGreeter(new ConsoleTeknoLogger());

            var greeting = await _greeter.GetGreetingAsync();
            greeting = DIExtensions.GreetIt(greeting);
            response.WriteString(greeting);

            return response;
        }
    }
}
