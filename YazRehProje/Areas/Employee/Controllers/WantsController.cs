using Entities.DTO.WantsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.ServiceManager;
using System.Data;

namespace YazRehProje.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Personel")]
    public class WantsController : Controller
    {
        private readonly IServiceManager _manager;

        public WantsController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult AddWants()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWants(WantsCreateDto wantsCreateDto)
        {
           if(ModelState.IsValid)
            {
                if (wantsCreateDto != null)
                {
                    _manager.WantServices.CreateOneWants(wantsCreateDto);
                    ViewBag.Add = "Ekleme Başarılı Oldu";
                    return View();
                }
            }
            ViewBag.AddError = "İstek Eklerken Hata Oluştu";
            return View();
        }
    }
}
