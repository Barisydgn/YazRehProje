using Microsoft.AspNetCore.Mvc;

namespace YazRehProje.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage(int code)
        {
            return View();
        }
    }
}
