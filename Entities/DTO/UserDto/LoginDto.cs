using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserDto
{
    public class LoginDto 
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Şifre Boş Geçilemez")]
        public string Password { get; set; }
        
    }
}
