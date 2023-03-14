using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace funcisolated
{
    public class ProcessOrders
    {
        private readonly ILogger _logger;

        public ProcessOrders(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ProcessOrders>();
        }

        [Function("ProcessOrders")]
        [QueueOutput("customer2queueout", Connection="myexternalstorage")]
        public OrderModel Run([QueueTrigger("customer2queue", Connection = "myexternalstorage")] OrderModel orderInput)
        {

            orderInput.Qty++;
            return orderInput;
        }
    }
}
