using Shared.Models;
using AzureServiceBus1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServiceBus1.Utilities
{
    public class Utility
    {
        private readonly IQueueService _queue;
        public Utility(QueueService queue)
        {
            _queue = queue;
        }

        public async Task PublishMessage(TransactionModel trans)
        {
            await _queue.SendMessageAsync(trans, "transactionqueue");
            trans = new TransactionModel();
        }
    }

    public class ResponseObject
    {
        public object Response { get; set; }

        public string StatusCode { get; set; }

        public string Description { get; set; }


    }
}
