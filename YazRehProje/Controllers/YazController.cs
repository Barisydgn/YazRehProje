using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositories.Context;
using Repositories.Repositories.Repositories.Employee;
using Repositories.Repositories.Repositories.RepositoryManager;
using Services.Services.ServiceManager;
using YazRehProje.Extensions;

namespace YazRehProje.Controllers
{
    public class YazController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IRepositoryManager _managerr;
        private readonly YazContext _context;


        public YazController(IServiceManager manager, IRepositoryManager managerr, YazContext context)
        {
            _manager = manager;
            _managerr = managerr;
            _context = context;
        }

        [HttpGet]
        public  IActionResult Employee()
        {
            return View(_manager.EmployeeServices.GetAllEmployee(trackChanges: true));
            //return View(_context.Employees.ToList());
        }

        [HttpGet]
        public   IActionResult EmployeeDetails(int id)
        {
            var employee=_manager.EmployeeServices.GetOneEmployee(id,trackChanges: true);
            return View(employee);
        }

        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult Rehabilitasyon()
        {
            return View();
        }

        public IActionResult Hakkımızda()
        {
            return View();
        }

        public IActionResult iletisim()
        {
            return View();
        }

        public IActionResult Randevu()
        {  
            return View();
        }

        public IActionResult FizikTedavi()
        {
            return View();
        }
        public IActionResult DilKonusma()
        {
            return View();
        }
        public IActionResult DuyuButunleme()
        {
            return View();
        }
        public IActionResult Ergoterapi()
        {
            return View();
        }
    }
}
