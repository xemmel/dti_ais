using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace myfunctionapp
{
    public class finalprocessorder
    {
        private readonly ILogger<finalprocessorder> _logger;

        public finalprocessorder(ILogger<finalprocessorder> logger)
        {
            _logger = logger;
        }

        [Function(nameof(finalprocessorder))]
        [QueueOutput("finalqueue", Connection = "storageaccountconnnection")]
        public  Order Run([QueueTrigger("outputqueue", Connection = "storageaccountconnnection")] Order order)
        {
            IGreeterHandler greeterHandler = new HappyGreetingHandler();
            var greeting = greeterHandler.GetGreetingAsync().GetAwaiter().GetResult();
            //Business Logic
            order.Qty++;
            return order;
        }
    }
}
