using Repositories.Repositories.Repositories.Employee;
using Repositories.Repositories.Repositories.StudentRepo;
using Repositories.Repositories.Repositories.WantRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.RepositoryManager
{
    public interface IRepositoryManager
    {
        IEmployeeRepositories EmployeeRepositories { get; }
        IStudentRepositories StudentRepositories { get; }
        IWantRepositories WantRepositories { get; }
        void SaveChanges();
    }
}
