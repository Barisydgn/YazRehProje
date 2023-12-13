using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.StudentDto
{
    public class StudentCreateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Age { get; set; }
        public string? Address { get; set; }
        public string? Diagnosis { get; set; }
        public string? Exercise { get; set; }
        public Employee Employee{ get; set; }
        public int EmployeeId { get; set; }
    }
}
