using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace myfunctionapp
{
    public class processorders
    {
        private readonly ILogger<processorders> _logger;

        public processorders(ILogger<processorders> logger)
        {
            _logger = logger;
        }

        [Function(nameof(processorders))]
        [QueueOutput("outputqueue", Connection = "storageaccountconnnection")]
        public Order Run([QueueTrigger("orderqueue", Connection = "storageaccountconnnection")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
            //extract orderId, itemNo, qty
            string[] messageParts = message.MessageText.Split('/');  
            string orderId = messageParts[0];
            string itemNo = messageParts[1];        
            int qty = int.Parse(messageParts[2]);        
            var order = new Order
            {
                OrderId = orderId,
                ItemNo = itemNo,
                Qty = qty
            };
            return order;
        }
    }
}
