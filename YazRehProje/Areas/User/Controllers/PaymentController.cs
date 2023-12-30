using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls.Crypto;
using Repositories.Context;
using Services.Services.PaymentServices;
using Services.Services.ServiceManager;
using Stripe;
using Stripe.Checkout;
using static System.Net.WebRequestMethods;

namespace YazRehProje.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class PaymentController : Controller
    {
        #region Deneme
        //private readonly IConfiguration _configuration;

        //public PaymentController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    StripeConfiguration.ApiKey = _configuration.GetSection("Stripe")["SecretKey"];
        //}

        //public IActionResult Index()
        //{
        //    var myViewModel = new PaymentViewModel
        //    {
        //        PublishableKey = "pk_test_51OMxHDEGXWDAglRnPYbAKT6cJCRX6JF61KpXepANQ2YArNFCfzs8UDiNUPOAKva6ibYAj4G3PLodJF2StSbyjmtZ00WDpKkQ8w"
        //    };


        //    return View(myViewModel);
        //}

        //[HttpPost]
        //public IActionResult Charge([FromBody] PaymentRequest paymentRequest)
        //{
        //    var options = new PaymentIntentCreateOptions
        //    {
        //        Amount = 500, // Ödeme tutarı (cent cinsinden), örneğin 5 dolar
        //        Currency = "usd",
        //        PaymentMethod = paymentRequest.Token,
        //        ConfirmationMethod = "manual", // İsteğe bağlı, gerektiğinde değiştirilebilir
        //        Confirm = true,
        //    };

        //    var service = new PaymentIntentService();
        //    var paymentIntent = service.Create(options);

        //    // Ödeme işlemi başarılıysa, başka bir işlem yapabilirsiniz (örneğin, veritabanına kaydetme).

        //    return RedirectToAction("PaymentSuccess");
        //}

        //public IActionResult PaymentSuccess()
        //{
        //    return View();
        //} 
        #endregion

        private readonly IConfiguration _configuration;
        private readonly YazContext _context;
        public INotyfService _notifyService { get; }

        public PaymentController(IConfiguration configuration, YazContext context, INotyfService notifyService)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration.GetSection("Stripe")["SecretKey"];
            _context = context;
            _notifyService = notifyService;
        }
      
     


      


        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession(int appointmentId)
        {
            var option = new SessionCreateOptions
            {
                SuccessUrl = $"https://localhost:7144/user/payment/success?id={appointmentId}",
                CancelUrl = "https://localhost:7144/user/payment/failure",
                PaymentMethodTypes = new List<string> { "card" },
                Mode = "payment", // Tek seferlik ödeme modu
                LineItems = new List<SessionLineItemOptions> {
                    new SessionLineItemOptions
                {
                       Price="price_1OMxMjEGXWDAglRnyl9fImOV",
                       Quantity=1
                },
                },
            };

            var service = new SessionService();
            try
            {
                var session = await service.CreateAsync(option);              
                return Redirect(session.Url);

            }
            catch (StripeException ex)
            {
                return BadRequest(ex.Message);
                
            }
            
        }

       


    
        [HttpGet]
        public IActionResult Success(int id)
        {

            #region Kod
            //if (TempData.ContainsKey("appointmentId"))
            //{
            //    var appointmentId = (int)TempData["appointmentId"];
            //    TempData.Keep("appointmentId"); 


            //    var appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == appointmentId);
            //    if (appointment != null)
            //    {
            //        appointment.Paid = true;
            //        _context.Appointments.Update(appointment);
            //        _context.SaveChanges();
            //    }


            //    ViewBag.AppointmentId = appointmentId;

            //return View();
            //} 
            #endregion

            var appointment=_context.Appointments.Where(x=> x.AppointmentId==id).FirstOrDefault();
            if(appointment != null)
            {
                appointment.Paid= true;
                _context.Appointments.Update(appointment);
                _context.SaveChanges();
                _notifyService.Success("Başarılı");
            }

            return View();
        }
        public IActionResult Failure()
        {
            _notifyService.Error("Başarısız");
            return View();
        }
    }
}
