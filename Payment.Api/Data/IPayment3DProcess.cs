using Payment.Api.Common;
using Payment.Api.Models.Requests;
using Payment.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Data
{
    public interface IPayment3DProcess
    {
        PaymentProcessType PaymentProcess { get; }
        Task<PaymentResponse> Finalize3DPayment(Payment3DFinalizeRequest request);
    }
}
