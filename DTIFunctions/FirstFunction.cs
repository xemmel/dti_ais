using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DTIFunctions.Interfaces;

namespace DTIFunctions
{
    public  class FirstFunction
    {
        private readonly IGreeter _greeter;

        public FirstFunction(IGreeter greeter)
        {
            _greeter = greeter;
        }
        [FunctionName("FirstFunction")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string responseMessage = _greeter.SendGreetings(payload: requestBody);

            return new OkObjectResult(responseMessage);
        }
    }
}
