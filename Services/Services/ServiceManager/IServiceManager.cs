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
    public interface IServiceManager
    {
        IEmployeeServices EmployeeServices { get; }
        IStudentServices StudentServices { get; }
        IWantServices WantServices { get; }
    }
}
