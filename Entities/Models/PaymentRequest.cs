using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PaymentRequest
    {
        public string StripeEmail { get; set; }
        public string Token { get; set; }
    }
}
