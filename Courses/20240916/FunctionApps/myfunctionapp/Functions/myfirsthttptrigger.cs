using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace myfunctionapp
{
    public class myfirsthttptrigger
    {
        private readonly ILogger _logger;
        private readonly IGreeterHandler _greeterHandler;

        public myfirsthttptrigger(ILoggerFactory loggerFactory, IGreeterHandler greeterHandler)
        {
            _logger = loggerFactory.CreateLogger<myfirsthttptrigger>();
            _greeterHandler = greeterHandler;
        }

        [Function("myfirsthttptrigger")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            //var greeter = new IGreeterHandler();
            var greeting = await _greeterHandler.GetGreetingAsync(cancellationToken: cancellationToken);
            response.WriteString(greeting);

            return response;
        }
    }
}
