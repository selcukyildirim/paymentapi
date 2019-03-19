using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payment.Api.Common;
using Payment.Api.Models.Requests;
using Payment.Api.Models.Responses;

namespace Payment.Api.Data.YapiKredi
{
    public class YapiKrediCreditCardPayment : IPaymentProcess
    {
        public PaymentProcessType PaymentProcess => PaymentProcessType.YapiKrediCreditCardPayment;

        public async Task<PaymentResponse> PaymentAsync(PaymentRequest request)
        {
            PaymentResponse paymentResponse = new PaymentResponse();
            paymentResponse.Result = $"{request.ProcessType.ToString()} : {request.CardNo} {request.Amount} TL Tutarında İşlem Yapıldı";
            return await Task.FromResult(paymentResponse);
        }
    }
   }
