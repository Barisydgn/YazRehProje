using Repositories.Context;
using Repositories.Repositories.Repositories.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.Employee
{
    public class EmployeeRepositories : RepositoryBase<Entities.Models.Employee>, IEmployeeRepositories
    {
        public EmployeeRepositories(YazContext context) : base(context)
        {
        }

        public void CreateOneEmployee(Entities.Models.Employee employee) => Create(employee);
        public void DeleteOneEmployee(Entities.Models.Employee employee)=> Delete(employee);
        //public Entities.Models.Employee GetOneEmployee(int id, bool trackChanges) => GetById(x => x.Equals(id), trackChanges).SingleOrDefault();
        public Entities.Models.Employee GetOneEmployee(int id, bool trackChanges) => GetById(x=> x.EmployeeId==id, trackChanges).SingleOrDefault();

        public void UpdateOneEmployee(Entities.Models.Employee employee) => Update(employee);

        IEnumerable<Entities.Models.Employee> IEmployeeRepositories.GetAllEmployee(bool trackChanges)=> GetAll(trackChanges);
    }
}
