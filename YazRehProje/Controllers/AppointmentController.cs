using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using YazRehProje.Extensions;

namespace YazRehProje.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly YazContext _context;

        public AppointmentController(YazContext context)
        {
            _context = context;
        }

        public IActionResult CreatedAppointment()
        {
            return View();
        }
    }
}
