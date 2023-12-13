using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ConfirmMail
    {
        public int Id { get; set; }
        public string Mail{ get; set; }
        public int ConfirmCode { get; set; }
    }
}
