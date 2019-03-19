using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Api.Common;
using Payment.Api.Models.Requests;
using Payment.Api.Models.Responses;

namespace Payment.Api.Data.YapiKredi
{
    public class YapiKredi3DPayment : IPaymentProcess, IPayment3DProcess
    {
        public PaymentProcessType PaymentProcess => PaymentProcessType.YapiKredi3DPayment;

        public async Task<PaymentResponse> Finalize3DPayment(Payment3DFinalizeRequest request)
        {

            PaymentResponse paymentResponse = new PaymentResponse();
            paymentResponse.Result = $"{request.PaymentProcessType.ToString()}  {request.Transaction} ile Ödeme Alındı Onaylandı.";
            return await Task.FromResult(paymentResponse);
        }

        public async Task<PaymentResponse> PaymentAsync(PaymentRequest request)
        {
            PaymentResponse paymentResponse = new PaymentResponse();
            paymentResponse.Result = $"{request.ProcessType.ToString()} : {request.CardNo} {request.Amount} İçin Bankaya Yönlendirildi.";
            return await Task.FromResult(paymentResponse);
        }
    }
}
