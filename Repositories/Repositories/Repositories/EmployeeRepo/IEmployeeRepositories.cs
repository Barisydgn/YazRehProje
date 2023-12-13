
using Entities.Models;
using Repositories.Repositories.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.Employee
{
    public interface IEmployeeRepositories:IRepositoryBase<Entities.Models.Employee>
    {
        void CreateOneEmployee(Entities.Models.Employee employee);
        void DeleteOneEmployee(Entities.Models.Employee employee);
        void UpdateOneEmployee(Entities.Models.Employee employee);
        IEnumerable<Entities.Models.Employee> GetAllEmployee(bool trackChanges);
        Entities.Models.Employee GetOneEmployee(int id,bool trackChanges);
    }
}
