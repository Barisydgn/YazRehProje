using AspNetCoreHero.ToastNotification.Abstractions;
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
        public INotyfService _notifyService { get; }

        public WantsController(IServiceManager manager, INotyfService notifyService)
        {
            _manager = manager;
            _notifyService = notifyService;
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
                    _notifyService.Success("Başarılı");
                    return View();
                }
            }
            ViewBag.AddError = "İstek Eklerken Hata Oluştu";
            _notifyService.Error("Başarısız");
            return View();
        }
    }
}
