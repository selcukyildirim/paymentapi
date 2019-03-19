using Payment.Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Models.Requests
{
    public class PaymentRequest
    {
        public string CardNo { get; set; }
        public decimal Amount { get; set; }
        public PaymentProcessType ProcessType { get; set; }
    }
}
