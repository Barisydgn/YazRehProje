using AutoMapper;
using Entities.DTO.UserDto;
using Entities.Enums;
using Entities.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using Repositories.Context;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YazRehProje.Controllers
{
    public class AccountController : Controller
    {
   
        private readonly UserManager<IdentityUser> _register;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly YazContext _context;
        private readonly IMapper _mapper;

        public AccountController(UserManager<IdentityUser> register, IMapper mapper, SignInManager<IdentityUser> signInManager, YazContext context)
        {

            _register = register;
            _mapper = mapper;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        
        public  IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm]LoginDto loginDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _register.FindByNameAsync(loginDto.Username);
                    var roles = await _register.GetRolesAsync(user);
                    //var userrole = _context.UserRoles.
                    if (user.EmailConfirmed == true && roles.Contains("Personel"))//BURADA MAİLİNİ ONAYLAYAN KULLANICILAR GİRİŞ YAPABİLİR 
                    {
                        return RedirectToAction("Anasayfa", "Employee", new { area = "Employee" });
                    }
                    else if (user.EmailConfirmed == true && roles.Contains("Admin"))
                    {

                        return RedirectToAction("List", "Admin", new { Area = "Admin" });
                    }
                    else if (user.EmailConfirmed == true && roles.Contains("User"))
                    {
                        //barisydgnnn 123456.Ba
                        return RedirectToAction("Index", "Appointment", new { area = "User" });
                    }
                    return View(loginDto);
                }
                return View();
            }
            return View();

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Anasayfa", "Yaz", new { area = "" });
        }



        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser( UserForRegistrationDto userForRegistrationDto)
        {


            #region Doğru Kod
            //if (ModelState.IsValid)
            //{
            //    Random random = new Random();
            //    int code;
            //    code = random.Next(100000, 1000000);
            //    IdentityUser appUser = new IdentityUser()
            //    {

            //        UserName = userForRegistrationDto.Username,
            //        Email = userForRegistrationDto.Email,  
            //    };
            //    var result = await _register.CreateAsync(appUser, userForRegistrationDto.Password);
            //    //if (result.Succeeded)
            //    //{
            //    //    MimeMessage mimeMessage = new MimeMessage();
            //    //    MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","baris_aydogan_36@hotmail.com");
            //    //    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
            //    //    mimeMessage.From.Add(mailboxAddressFrom);
            //    //    mimeMessage.To.Add(mailboxAddressTo);
            //    //    var bodyBuilder = new BodyBuilder();
            //    //    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz : " + code;
            //    //    mimeMessage.Body=bodyBuilder.ToMessageBody();
            //    //    mimeMessage.Subject = "Yaz Rehabilitasyon Onay Kodu";
            //    //    SmtpClient smtpClient= new SmtpClient();
            //    //    smtpClient.Connect("smpt.gmail.com", 587, false);
            //    //    smtpClient.Authenticate("baris_aydogan_36@hotmail.com", "tild mudt fehx vssy");
            //    //    smtpClient.Send(mimeMessage);
            //    //    smtpClient.Disconnect(true);

            //    //    TempData["Mail"] = userForRegistrationDto.Email;


            //    //    return RedirectToAction("ConfirmMail", "Account");
            //    //}
            //    //else
            //    //{
            //    //    foreach (var item in result.Errors)
            //    //    {
            //    //        ModelState.AddModelError("", item.Description);//BU İFADE CSHTML KISMINDAKİ KAYIT OLMA SIRASINDAKİ HATALARI EKRANA YAZDIRIYOR
            //    //    }
            //    //}
            //}
            //return View();
            #endregion

            //if (ModelState.IsValid)
            //{

            if (ModelState.IsValid)
            {
                var existingUserByEmail = await _register.FindByEmailAsync(userForRegistrationDto.Email);

                if (existingUserByEmail != null)
                {
                    ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılıyor.");
                    return View();
                }

                var existingUserByUsername = await _register.FindByNameAsync(userForRegistrationDto.Username);
                if (existingUserByUsername != null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı zaten kullanılıyor.");
                    return View();
                }


                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);
                IdentityUser appUser = new IdentityUser()
                {
                    UserName = userForRegistrationDto.Username,
                    Email = userForRegistrationDto.Email,
                };
                var result = await _register.CreateAsync(appUser, userForRegistrationDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "barisydgnn@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz : " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Yaz Rehabilitasyon Onay Kodu";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("barisydgnn@gmail.com", "cotx xsfe uevl psny");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                    TempData["Mail"] = userForRegistrationDto.Email;
                    TempData["Code"] = code;
                    return RedirectToAction("ConfirmMail", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);//BU İFADE CSHTML KISMINDAKİ KAYIT OLMA SIRASINDAKİ HATALARI EKRANA YAZDIRIYOR
                    }
                }
                //}
                return View();
            }
            return View();
        }

        [HttpGet]
        public  IActionResult ConfirmMail()
        {            
            return View();
        }
        //MAİL YOLLAMA
        [HttpPost]
        public async Task<IActionResult> ConfirmMail(ConfirmMailDto confirmMailDto)
        {
            var codee = TempData["Code"] as int?;
           var user =await _register.FindByEmailAsync(confirmMailDto.Mail);           
            if (confirmMailDto.Code == confirmMailDto.UserCode)
            {
                user.EmailConfirmed = true;
                await _register.UpdateAsync(user);
                await _register.AddToRoleAsync(user, "User");
                return RedirectToAction("Login", "Account");
           
            }
            return View();
        }



        //ŞİFRE SIFIRLAMA
        [HttpGet]
       public IActionResult ResetPassword()
       {
            return View();
       }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserForRegistrationDto userForRegistrationDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code;
                code = random.Next(100000, 1000000);
                var email = await _register.FindByEmailAsync(userForRegistrationDto.Email);
                if (email is not null)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "barisydgnn@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", userForRegistrationDto.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Şifre sıfırlamak için onay kodunuz : " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Yaz Rehabilitasyon Onay Kodu";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Connect("smtp.gmail.com", 587, false);
                    smtpClient.Authenticate("barisydgnn@gmail.com", "cotx xsfe uevl psny");
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);
                    TempData["Mail"] = userForRegistrationDto.Email;
                    TempData["Code"] = code;
                    return RedirectToAction("ResetPassword2", "Account");
                }
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword2()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> ResetPassword2(int userCode, int code, string mail,string password)
        {
          
            var user = await _register.FindByEmailAsync(mail);
            if (code == userCode)
            {
                var token = await _register.GeneratePasswordResetTokenAsync(user);
                var result=  await  _register.ResetPasswordAsync(user, token, password);
               if(result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        // Hataları ViewBag'e eklemek
                        ViewBag.ErrorMessage = error.Description;
                    }

                    return View();
                }
            }
            return View();
        }

    }
}
