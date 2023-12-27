using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Entities.DTO.StudentDto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Repositories.Repositories.RepositoryManager;
using Services.Services.ServiceManager;

namespace YazRehProje.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repo;
        private readonly YazContext _context;
        public INotyfService _notifyService { get; }

        public StudentsController(IServiceManager manager, IMapper mapper, YazContext context, IRepositoryManager repo, INotyfService notifyService)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
            _repo = repo;
            _notifyService = notifyService;
        }

        public IActionResult List() 
        {
            //ÖĞRENCİLİK DURUMU AKTİF VEYA DEĞİL İÇERİĞİ DE YAP
            #region Bağlantılı Tablo Normal Kodlama
            //BUNU N KATMANLIYA ÇEVİRMEK İÇİN  STUDENT REPO KISMINA BAK ORAYA EKLEDİM ONU DENE
            // var students = _context.Students.Include(x => x.Employee).ToList();
            //return View(students); 
            #endregion
            var students=_manager.StudentServices.GetAllStudent(trackChanges: true);
            return View(students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            var employee=_context.Employees.ToList();
            return View(new StudentCreateDto2 { Employees = employee });
        }

        [HttpPost]
        public IActionResult AddStudent(StudentCreateDto2 studentCreateDto2)
        {
            //MODELSTATE HATA VERİYOR NASIL ÇÖZÜCEZ ACABA

           
            //if (ModelState.IsValid )
            //{
                
                if (studentCreateDto2 != null)
                {
                    _manager.StudentServices.CreateOneStudent(studentCreateDto2);
                _notifyService.Success("Başarılı");
                    return View("List", _manager.StudentServices.GetAllStudent(trackChanges: true));
                }

            //}

            var employee = _context.Employees.ToList();
            ViewBag.AddError = "Ekleme Yaparken Hata Oluştu";
            _notifyService.Error("Başarısız");
            return View(new StudentCreateDto2 { Employees = employee });
        }

        public IActionResult DeleteStudent(int id)
        {
            _manager.StudentServices.DeleteOneStudent(id,trackChanges: true);
           
            return View("List",_manager.StudentServices.GetAllStudent(trackChanges : true));
        }

        public IActionResult UpdateStudent(int id)
        {
            var student=_manager.StudentServices.GetOneStudent(id,trackChanges: true);
            var employee = _context.Employees.ToList();

            return View(new StudentUpdateDto
            {
            StudentId=student.StudentId,
            Name=student.Name,
            Surname=student.Surname,
            Age=student.Age,
            Address=student.Address,
            Diagnosis=student.Diagnosis,
            Exercise=student.Exercise,
            EmployeeId=student.EmployeeId,
            Employees=employee
            });
        }

        [HttpPost]
        public IActionResult UpdateStudent(StudentUpdateDto studentUpdateDto)
        {
            //if (ModelState.IsValid)
            //{
                if (studentUpdateDto != null)
                {
                    _manager.StudentServices.UpdateOneStudent(studentUpdateDto, studentUpdateDto.StudentId, true);
                _notifyService.Success("Başarılı");
                return View("List", _manager.StudentServices.GetAllStudent(trackChanges: true));
                }
            //}
            var employee = _context.Employees.ToList();
            ViewBag.UpdateError = "Güncelleme Yaparken Hata Oluştu";
            _notifyService.Error("Başarısız");
            return View(new StudentUpdateDto
            {
                StudentId = studentUpdateDto.StudentId,
                Name = studentUpdateDto.Name,
                Surname = studentUpdateDto.Surname,
                Age = studentUpdateDto.Age,
                Address = studentUpdateDto.Address,
                Diagnosis = studentUpdateDto.Diagnosis,
                Exercise = studentUpdateDto.Exercise,
                EmployeeId = studentUpdateDto.EmployeeId,
                Employees = employee
            });
        }
    }
}
