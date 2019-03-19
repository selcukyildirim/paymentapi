using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Api.Data;
using Payment.Api.Models.Requests;
using Payment.Api.Models.Responses;

namespace Payment.Api.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IEnumerable<IPaymentProcess> _paymentService;
        private readonly IEnumerable<IPayment3DProcess> _payment3DService;

        public PaymentService(IEnumerable<IPaymentProcess> paymentProcesses, IEnumerable<IPayment3DProcess> payment3DService)
        {
            _paymentService = paymentProcesses;
            _payment3DService = payment3DService;
        }

        public async Task<PaymentResponse> Finalize3DPaymentAsync(Payment3DFinalizeRequest request)
        {
            PaymentResponse paymentResponse = await _payment3DService.FirstOrDefault(x => x.PaymentProcess == request.PaymentProcessType).Finalize3DPayment(request);
            return paymentResponse;
        }

        public async Task<PaymentResponse> PaymentAsync(PaymentRequest request)
        {
            PaymentResponse paymentResponse = await _paymentService.FirstOrDefault(x => x.PaymentProcess == request.ProcessType).PaymentAsync(request);
            return  paymentResponse;
        }
    }
}
