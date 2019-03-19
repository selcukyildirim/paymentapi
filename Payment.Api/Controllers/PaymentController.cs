using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.Api.Models.Requests;
using Payment.Api.Models.Responses;
using Payment.Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Payment.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/payment")]
    [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No value found for requested filter.")]
    [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
    [SwaggerResponse((int)HttpStatusCode.Forbidden, Description = "Access not allowed.")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
     
  
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PaymentResponse))]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Payment(PaymentRequest paymentRequest)
        {
            PaymentResponse paymentResponse = await _paymentService.PaymentAsync(paymentRequest);
            if (paymentResponse!=null && string.IsNullOrEmpty(paymentResponse.Result))
            {
                return BadRequest();
            }
            return Ok(paymentResponse);
        }


        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PaymentResponse))]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Finalize3DPayment(Payment3DFinalizeRequest request)
        {
            PaymentResponse paymentResponse = await _paymentService.Finalize3DPaymentAsync(request);
            if (paymentResponse != null && string.IsNullOrEmpty(paymentResponse.Result))
            {
                return BadRequest();
            }
            return Ok(paymentResponse);
        }

    }
}