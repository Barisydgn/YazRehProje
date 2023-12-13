using Repositories.Context;
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
    public class RepositoryManager : IRepositoryManager
    {
        private readonly YazContext _context;
        private readonly IEmployeeRepositories _employeeRepositories;
        private readonly IWantRepositories _wantRepositories;
        private readonly IStudentRepositories _studentRepositories;

        public RepositoryManager(YazContext context, IEmployeeRepositories employeeRepositories, IWantRepositories wantRepositories, IStudentRepositories studentRepositories)
        {
            _context = context;
            _employeeRepositories = employeeRepositories;
            _wantRepositories = wantRepositories;
            _studentRepositories = studentRepositories;
        }

        public IEmployeeRepositories EmployeeRepositories => _employeeRepositories;

        public IStudentRepositories StudentRepositories => _studentRepositories;

        public IWantRepositories WantRepositories => _wantRepositories;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
