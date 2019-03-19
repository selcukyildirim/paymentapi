using Payment.Api.Models.Requests;
using Payment.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Api.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> PaymentAsync(PaymentRequest request);
        Task<PaymentResponse> Finalize3DPaymentAsync(Payment3DFinalizeRequest request);
    }
}
