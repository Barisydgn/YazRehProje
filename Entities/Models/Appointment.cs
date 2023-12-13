using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Appointment //SADECE RANDEVU ALMA KALDI
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public bool BosDolu { get; set; }
        //public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }

    }
}
