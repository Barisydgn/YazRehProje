using AutoMapper;
using Microsoft.Extensions.FileProviders;
using Repositories.Repositories.Repositories.RepositoryManager;
using Services.Services.EmployeeServices;
using Services.Services.StudentServices;
using Services.Services.WantsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeServices> _employeeServices;
        private readonly Lazy< IStudentServices> _studentServices;
        private readonly Lazy <IWantServices> _wantServices;

        public ServiceManager(IEmployeeServices employeeServices, IStudentServices studentServices, IWantServices wantServices,IRepositoryManager manager,IMapper mapper,IFileProvider fileProvider)
        {
            _employeeServices = new Lazy<IEmployeeServices>(() => new Services.EmployeeServices.EmployeeServices(manager, mapper, fileProvider));
            _studentServices = new Lazy<IStudentServices>(() => new Services.StudentServices.StudentServices(manager, mapper));
            _wantServices = new Lazy<IWantServices>(() => new Services.WantsServices.WantServices(manager, mapper));
        }

        public IEmployeeServices EmployeeServices => _employeeServices.Value;

        public IStudentServices StudentServices => _studentServices.Value;

        public IWantServices WantServices => _wantServices.Value;
    }
}
