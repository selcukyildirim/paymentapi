using Payment.Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Models.Requests
{
    public class Payment3DFinalizeRequest
    {
        public string Transaction { get; set; }
        public PaymentProcessType PaymentProcessType { get; set; }
    }
}
