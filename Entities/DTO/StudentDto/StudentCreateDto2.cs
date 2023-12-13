using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StudentDto
{
    public class StudentCreateDto2
    {
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ad maksimum 30 minimum 3 harf olabilir ")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Soyad maksimum 50 minimum 3 harf olabilir ")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [RegularExpression("^[0-50]+$", ErrorMessage = "Sadece sayı girişi yapılabilir.")]
        public string? Age { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(300,ErrorMessage ="Maksimum 300 karakter olabilir")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        public string? Diagnosis { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(500,MinimumLength =30,ErrorMessage ="Maksimum 500 harf minimum 30 harf olmalı")]
        public string? Exercise { get; set; }
        public Employee Employee { get; set; }

        [Required(ErrorMessage ="Boş Geçilemez")]
        public int EmployeeId { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
