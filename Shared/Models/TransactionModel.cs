using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class TransactionModel
    {
        public string debitAccount { get; set; }
        public string creditAccount { get; set; }
        public decimal amount { get; set; }
    }
}
