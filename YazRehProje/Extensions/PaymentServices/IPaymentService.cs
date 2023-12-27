using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.PaymentServices
{
    public interface IPaymentService
    {
        Task<string> ProcessPayment(string token, decimal amount);
    }
}
