using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.WantsDto
{
    public class WantsUpdateDto
    {
        public int WantsId { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string? Explanation { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string? Description { get; set; }
        public Conclusion Conclusion { get; set; }
    }
}
