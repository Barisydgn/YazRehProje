using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.EmployeeDto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public GenderStatus GenderStatus { get; set; }
    }
}
