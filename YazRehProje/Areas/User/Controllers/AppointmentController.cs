using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Entities.DTO.AppointmentDto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repositories.Context;

namespace YazRehProje.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]

    public class AppointmentController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly YazContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<IdentityUser> _signInManager;
        public INotyfService _notifyService { get; }
        public AppointmentController(YazContext context, IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, INotyfService notifyService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _notifyService = notifyService;
        }
        public IActionResult CreateAppointment(int appointmentId, string otherInfo)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            var mapper = _mapper.Map<AppointmentDto>(appointment);
            return View(mapper);
        }

        public JsonResult UpdateAppointment(Appointment appointment)
        {
            var appoin = _context.Appointments.Where(x=> x.AppointmentId==appointment.AppointmentId).FirstOrDefault();
            appoin.AppointmentId=appointment.AppointmentId;
            appoin.AppointmentDate=appointment.AppointmentDate;
            appoin.AppointmentTime=appointment.AppointmentTime;
            appoin.StudentName=appointment.StudentName;
            appoin.StudentSurname=appointment.StudentSurname;
            appoin.BosDolu=appointment.BosDolu;
            appoin.Paid=appointment.Paid;
            var json = JsonConvert.SerializeObject(appointment);
            return Json(json);
        }

        [HttpPost]
        public IActionResult CreateAppointment(AppointmentDto AppointmentDto)
        {
              if(AppointmentDto is not null)
            {
                var appointment = _mapper.Map<Appointment>(AppointmentDto);
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                _notifyService.Success("Başarılı");
                return RedirectToAction("List", _context.Appointments.ToList());
            }
            _notifyService.Error("Başarısız");
            return RedirectToAction("List", _context.Appointments.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Ajax(string selectedDate)
        {
            DateTime date = DateTime.Parse(selectedDate);
            var filteredAppointments = _context.Appointments.Where(x => x.AppointmentDate.Date==date && x.Paid==false ).ToList();
            return PartialView("_AppointmentPartial", filteredAppointments);
        }
        public IActionResult List()
        {
           return View();
        }
    }
}
