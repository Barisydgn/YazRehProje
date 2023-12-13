using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppointmentDto
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage ="Tarih Boş Bırakılamaz")]
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "Saat Boş Bırakılamaz")]
        public TimeSpan AppointmentTime { get; set; }
        [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
        [StringLength(50,ErrorMessage ="Ad En Fazla 50 Karakter Olabilir")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Soyad Boş Bırakılamaz")]
        [StringLength(50, ErrorMessage = "Soyad En Fazla 50 Karakter Olabilir")]
        public string StudentSurname { get; set; }
        public bool BosDolu { get; set; }
    }
}
