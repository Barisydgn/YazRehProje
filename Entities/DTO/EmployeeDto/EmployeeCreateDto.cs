using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmployeeDto
{
    public class EmployeeCreateDto
    {
        //FORM VALİDATİON EKLE

        [Required(ErrorMessage ="Boş Bırakılamaz")]
        [StringLength(30,MinimumLength =3 , ErrorMessage ="Ad maksimum 30 minimum 3 harf olabilir ")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Soyad maksimum 50 minimum 3 harf olabilir ")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ad maksimum 50 minimum 3 harf olabilir ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        //[RegularExpression("^[0-50]+$", ErrorMessage = "Sadece sayı girişi yapılabilir.")]

        public string? Age { get; set; }
        [Required(ErrorMessage = "Boş Bırakılamaz")]
        [StringLength(300)]
        public string? Address { get; set; }
        [Required(ErrorMessage ="Boş Bırakılamaz")]
        [EmailAddress(ErrorMessage ="Sadece Mail Adresi Giriniz")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Boş Bırakılamaz")]
        public GenderStatus GenderStatus { get; set; }
        public IFormFile Image { get; set; }
        public string? ImagePath{ get; set; }
    }
}
