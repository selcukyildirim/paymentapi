using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Common
{
    public enum PaymentProcessType
    {
        GarantiCreditCardPayment,
        Garanti3DPayment,
        YapiKrediCreditCardPayment,
        YapiKredi3DPayment
    }
}
