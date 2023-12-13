using Entities.DTO.EmployeeDto;
using Entities.DTO.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.StudentServices
{
    public interface IStudentServices
    {
        Entities.Models.Student CreateOneStudent(StudentCreateDto2 studentCreateDto2);
        void UpdateOneStudent(StudentUpdateDto studentUpdateDto, int id, bool trackChanges);
        void DeleteOneStudent(int id, bool trackChanges);
        Entities.Models.Student GetOneStudent(int id, bool trackChanges);
        IEnumerable<Entities.Models.Student> GetAllStudent(bool trackChanges);
    }
}
