using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Details { get; set; }
        //FOTOĞRAFTA EKLE
        public GenderStatus GenderStatus { get; set; }//CİNSİYET

       //[ValidateNever]
        public string ImagePath { get; set; }

        
        /*/*[notmapped]**////VERİ TABANINDA SAKLANMAMASI İÇİN YAZILAN KOD
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
