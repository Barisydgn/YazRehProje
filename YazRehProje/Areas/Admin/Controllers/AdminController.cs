using AutoMapper;
using Entities.DTO.EmployeeDto;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Repositories.Context;
using Repositories.Repositories.Repositories.RepositoryManager;
using Services.Services.ServiceManager;

namespace YazRehProje.Areas.Admin.Controllers
{
   
    public class AdminController : AdminBaseControlller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminController(IFileProvider fileProvider, IServiceManager manager, IMapper mapper, SignInManager<IdentityUser> signInManager)
        {
            _fileProvider = fileProvider;
            _manager = manager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public IActionResult Anasayfa()
        {
            return View();
        }


        public IActionResult List()
        {
            return View(_manager.EmployeeServices.GetAllEmployee(true));
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeCreateDto employeeCreateDto)
        {

            
            if (ModelState.IsValid)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var images = root.First(x => x.Name == "images");
                var randomİmages = Guid.NewGuid() + Path.GetExtension(employeeCreateDto.Image.FileName);
                var path = Path.Combine(images.PhysicalPath, randomİmages);
                using var stream = new FileStream(path, FileMode.Create);
                employeeCreateDto.Image.CopyTo(stream);
                employeeCreateDto.ImagePath = randomİmages;
                if (employeeCreateDto is not null)
                {
                    _manager.EmployeeServices.CreateOneEmployee(employeeCreateDto);
                    return View("List", _manager.EmployeeServices.GetAllEmployee(true));
                }
            }
            ViewBag.Error = "Kayıt Yaparken Hata Oluştu";
            return View(employeeCreateDto);
        }

       
        public IActionResult DeleteEmployee(int id)
        {
           _manager.EmployeeServices.DeleteOneEmployee(id,trackChanges:true);
            return View("List",_manager.EmployeeServices.GetAllEmployee(true));
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {

            var employee=_manager.EmployeeServices.GetOneEmployee(id,trackChanges: true);
            var dto=_mapper.Map<EmployeeUpdateDto>(employee);
            return View(dto);
        }
        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeUpdateDto employeeUpdateDto)
        {
           //if(ModelState.IsValid)
           // {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var images = root.First(x => x.Name == "images");
                var randomİmages = Guid.NewGuid() + Path.GetExtension(employeeUpdateDto.Image.FileName);
                var path = Path.Combine(images.PhysicalPath, randomİmages);
                using var stream = new FileStream(path, FileMode.Create);
                employeeUpdateDto.Image.CopyTo(stream);
                employeeUpdateDto.ImagePath = randomİmages;
                if (employeeUpdateDto is not null)
                {
                    //var employedto = _mapper.Map<Entities.Models.Employee>(employeeUpdateDto);
                    _manager.EmployeeServices.UpdateOneEmployee(employeeUpdateDto, employeeUpdateDto.EmployeeId, trackChanges: true);
                    return View("List", _manager.EmployeeServices.GetAllEmployee(true));
                }
            //}
            ViewBag.UpdateError = "Güncelleme Yaparken Hata Oluştu";
           
            return View(new EmployeeUpdateDto
            {
                Name= employeeUpdateDto.Name,
                Surname= employeeUpdateDto.Surname,
                Title= employeeUpdateDto.Title,
                Age= employeeUpdateDto.Age,
                Address= employeeUpdateDto.Address,
                Email= employeeUpdateDto.Email,
                GenderStatus= employeeUpdateDto.GenderStatus
            });
         
        }
    }
}
