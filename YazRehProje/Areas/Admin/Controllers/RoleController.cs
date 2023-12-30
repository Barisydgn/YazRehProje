using AspNetCoreHero.ToastNotification.Abstractions;
using Entities.DTO.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repositories.Context;
using System.Data;

namespace YazRehProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly YazContext _context;
        public INotyfService _notifyService { get; }

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, YazContext context, INotyfService notifyService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            var usersWithRoles = new List<Entities.DTO.UserDto.UserRoleDto>();

            foreach (var user in _userManager.Users.ToList())
            {
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    if (!roles.Contains("Admin"))
                    {
                        var userWithRoles = new Entities.DTO.UserDto.UserRoleDto
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            Email = user.Email,
                            Roles = roles.ToList(),
                        };

                        usersWithRoles.Add(userWithRoles);
                    }
                 
                }
            }


            return View(usersWithRoles);
        }

        [HttpGet]
        public async Task <IActionResult> UpdateRole(string id)
        {
            var user=_userManager.FindByIdAsync(id);
       var role=  await   _context.Roles.ToListAsync();
            var roles = await _userManager.GetRolesAsync(user.Result);

            // roles listesi artık kullanıcının sahip olduğu rolleri içerir
            var userDto = new UserRoleDto2
            {
                Email = user.Result.Email,
                UserId = user.Result.Id,
                UserName = user.Result.UserName,
                Roles = role
            };

            return View(userDto);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateRole(UserRoleDto2 userRoleDto2)
        {
            var user =await _userManager.FindByIdAsync(userRoleDto2.UserId);

            var result = _userManager.AddToRoleAsync(user,userRoleDto2.roleName);
            if (result.Result.Succeeded)
            {
                _notifyService.Success("Başarılı");
                return RedirectToAction("Index", "Role", new { area = "Admin" });
            }
            _notifyService.Error("Başarısız");
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> DeleteRol(string id)
        {
            var user = _userManager.FindByIdAsync(id);
           
          if(user is not null)
            {
                var roles = _userManager.GetRolesAsync(user.Result);
                ViewBag.Roles= roles;
                var model = new DeleteRoleDto
                {
                    UserId = user.Result.Id,
                    UserName = user.Result.UserName,
                    Roles = roles.Result.ToList()
                };
                return View(model);
          }
            return View();
        }
        [HttpPost]       
        public async Task<IActionResult> DeleteRol(DeleteRoleDto deleteRoleDto)
        {
            var user = await _userManager.FindByIdAsync(deleteRoleDto.UserId);
            if(user is not null ) 
            {
                if(await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return BadRequest("Admin rolüne sahip bir kullanıcının rolü değiştirilemez.");
                }
                else
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, deleteRoleDto.RoleId);
                    if(result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        var userWithRoles = new Entities.DTO.UserDto.UserRoleDto
                        {
                            UserId = user.Id,
                            UserName = user.UserName,
                            Email = user.Email,
                            Roles = roles.ToList(),
                        };

                        var usersWithRoles = new List<Entities.DTO.UserDto.UserRoleDto> { userWithRoles };

                        return View("Index", usersWithRoles);

                    }
                    else
                    {
                        ModelState.AddModelError("", "Rol kaldırma işlemi başarısız oldu.");
                        return View(deleteRoleDto);
                    }
                }


            }
            else
            {
                return View();
            }
        }

       
    }
}
