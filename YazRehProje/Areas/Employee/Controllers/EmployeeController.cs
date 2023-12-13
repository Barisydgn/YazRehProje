using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace YazRehProje.Areas.Employee.Controllers
{
 
    [Area("Employee")]
    [Authorize(Roles = "Personel")]
    public class EmployeeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public EmployeeController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Anasayfa()
        {
            return View();
        }

       
    }
}
