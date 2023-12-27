using Entities.Models;
using Microsoft.Extensions.Options;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {

        private readonly string _secretKey;

        public PaymentService(IOptions<StripeSettings> options)
        {
            _secretKey = options.Value.SecretKey;
        }

       

        public async Task<string> ProcessPayment(string token, decimal amount)
        {
            var options = new ChargeCreateOptions
            {
                Amount = (long)(amount * 100), // Stripe uses cents
                Currency = "usd",
                Source = token,
                Description = "Payment for Order"
            };

            var service = new ChargeService();
            var charge = await service.CreateAsync(options);

            return charge.Id;
        }

    }
}
