using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserDto
{
    public class UserForRegistrationDto
    {
        public int Code { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string ConfirmPassword { get; set; }
    }
}
