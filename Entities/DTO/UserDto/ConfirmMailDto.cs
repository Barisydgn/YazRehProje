using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.UserDto
{
    public class ConfirmMailDto
    {
        [Required(ErrorMessage ="Mail Adresi Boş Geçilemez")]
        public string Mail { get; set; }
        public int UserCode { get; set; }
        public int Code { get; set; }
    }
}
