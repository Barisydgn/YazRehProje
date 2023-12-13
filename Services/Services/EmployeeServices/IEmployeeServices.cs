using Entities.DTO.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        Entities.Models.Employee CreateOneEmployee(EmployeeCreateDto employeeCreateDto);
        void UpdateOneEmployee(EmployeeUpdateDto employeeUpdateDto, int id, bool trackChanges);
        void DeleteOneEmployee(int id, bool trackChanges);
        Entities.Models.Employee GetOneEmployee(int id, bool trackChanges);
        IEnumerable<Entities.Models.Employee> GetAllEmployee(bool trackChanges);
    }
}
