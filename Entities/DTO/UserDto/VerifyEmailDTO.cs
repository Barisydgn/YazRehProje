using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserDto
{
    public class VerifyEmailDTO
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string NewPassword { get; set; }
        public string CorfirmPassword { get; set; }
    }
}
