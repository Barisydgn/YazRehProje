using AutoMapper;
using Entities.DTO.WantsDto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.ServiceManager;

namespace YazRehProje.Areas.Admin.Controllers
{
    //[Authorize]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class WantsController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public WantsController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        //LİSTELEME ve SİLME YAPILDI GÜNCELLEME   KALDI EKLEME İSE EMPLOYEE AREASINDA OLACAK
        public IActionResult List()
        {
            return View(_manager.WantServices.GetAllWants(trackChanges : true));
        }

        public IActionResult DeleteWants(int id)
        {
            _manager.WantServices.DeleteOneWants((int)id,trackChanges:true);
            return View("List", _manager.WantServices.GetAllWants(true));
        }

        public IActionResult UpdateWants(int id)
        {
            var wants = _manager.WantServices.GetOneWants(id, trackChanges: true);
        return View(new WantsUpdateDto
        {
            WantsId=wants.WantsId,
            Explanation=wants.Explanation,
            Description=wants.Description,
            Conclusion=wants.Conclusion
        });
        }

        [HttpPost]
        public IActionResult UpdateWants(WantsUpdateDto wantsUpdateDto)
        {
           if(ModelState.IsValid)
            {
               
                if (wantsUpdateDto is not null)
                {
                    _manager.WantServices.UpdateOneWants(wantsUpdateDto, wantsUpdateDto.WantsId, trackChanges: true);
                    return View("List", _manager.WantServices.GetAllWants(true));
                }
            }
            ViewBag.UpdateError = "Güncelleme Yaparken Hata Oluştu";
            return View(new WantsUpdateDto
            {
                WantsId = wantsUpdateDto.WantsId,
                Explanation = wantsUpdateDto.Explanation,
                Description = wantsUpdateDto.Description,
                Conclusion = wantsUpdateDto.Conclusion
            });
            
        }
    }
}
