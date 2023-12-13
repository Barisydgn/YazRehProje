using AutoMapper;
using Entities.DTO.StudentDto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Context;
using Repositories.Repositories.Repositories.RepositoryManager;
using Services.Services.ServiceManager;

namespace YazRehProje.Areas.Employee.Controllers
{
 
    [Area("Employee")]
    [Authorize(Roles = "Personel")]
    public class StudentController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repo;
        private readonly YazContext _context;


        public StudentController(IServiceManager manager, IMapper mapper, YazContext context, IRepositoryManager repo)
        {
            _manager = manager;
            _mapper = mapper;
            _context = context;
            _repo = repo;
        }

        public IActionResult List()
        { 
            var students = _manager.StudentServices.GetAllStudent(trackChanges: true);
            return View(students);
        }

        public IActionResult UpdateStudent(int id)
        {
            var student = _manager.StudentServices.GetOneStudent(id, trackChanges: true);
            var employee = _context.Employees.ToList();

            return View(new StudentUpdateDto
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Address = student.Address,
                Diagnosis = student.Diagnosis,
                Exercise = student.Exercise,
                EmployeeId = student.EmployeeId,
                Employees = employee
            });
        }

        [HttpPost]
        public IActionResult UpdateStudent(StudentUpdateDto studentUpdateDto)
        {
         if(ModelState.IsValid)
            {
                if (studentUpdateDto != null)
                {
                    _manager.StudentServices.UpdateOneStudent(studentUpdateDto, studentUpdateDto.StudentId, true);
                    return View("List", _manager.StudentServices.GetAllStudent(trackChanges: true));
                }
            }
            ViewBag.UpdateError = "Güncelleme Yaparken Hata Oluştu";
            var employee = _context.Employees.ToList();
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
