using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PaymentViewModel
    {
        public string PublishableKey { get; set; }
        public int AppointmentId { get; set; }
        public string SessionId { get; set; }
        public string Url { get; set; }
        //public string SessionId { get; set; }
    }
}
