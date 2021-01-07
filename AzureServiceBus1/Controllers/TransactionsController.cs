using AzureServiceBus1.Services;
using AzureServiceBus1.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureServiceBus1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IQueueService _queue;
        private ResponseObject responseObject;
        public TransactionsController(IQueueService queue)
        {
            _queue = queue;
        }
        [HttpPost]
        public IActionResult Transfer(TransactionModel trans)
        {
            try
            {
                //var resp = _transactionRepo.Transfer(trans);
                var resp = _queue.SendMessageAsync(trans, "transactionqueue");
                trans = new TransactionModel();

                responseObject = new ResponseObject()
                {
                    Response = resp,
                    Description = "",
                    StatusCode = "00"
                };
                return StatusCode(500, responseObject);
            }

            catch (Exception ex)
            {
                responseObject = new ResponseObject()
                {
                    Response = null,
                    Description = ex.Message,
                    StatusCode = "99"
                };
                return StatusCode(500, responseObject);
            }
        }
    }
}
