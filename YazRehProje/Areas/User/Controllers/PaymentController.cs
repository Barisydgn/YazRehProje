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
        //public IActionResult Index()
        //{


        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}


        //[HttpPost]
        
        public IActionResult Index(int appointmentId)
        {
            TempData["appointmentId"] = appointmentId;
            //var paymentResponse = ViewData["PaymentResponse"] as string;
            var myViewModel = new PaymentViewModel
            {
                PublishableKey = "pk_test_51OMxHDEGXWDAglRnPYbAKT6cJCRX6JF61KpXepANQ2YArNFCfzs8UDiNUPOAKva6ibYAj4G3PLodJF2StSbyjmtZ00WDpKkQ8w",
               AppointmentId= appointmentId
            };


            return View(myViewModel);
        }


        [HttpGet]
        public IActionResult StripeWebhook()
        {
            // Stripe webhook'unu işleyin ve ödeme durumunu kontrol edin
            var json = string.Empty;

            using (var reader = new StreamReader(HttpContext.Request.Body))
            {
                json = reader.ReadToEnd();
            }

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], "whsec_duahTEv7vkODGQGmoSfOFV4dVFzTNmU2");

            // Stripe'dan gelen olayı kontrol edin
            if (stripeEvent.Type == Events.PaymentIntentSucceeded)
            {
                // Ödeme başarılı, gerekli işlemleri gerçekleştirin
                // Bu noktada gelen bilgilere göre ödemenin başarılı olduğunu anlamış olursunuz.
                // Örneğin: var paymentIntentId = stripeEvent.Data.Object.Id;

                var appointmentId = HttpContext.Request.Query["appointmentId"];
               if(!string.IsNullOrEmpty(appointmentId))
                {
                    var appointment = _context.Appointments.Find(appointmentId);
                    appointment.Paid = true;
                    _context.Appointments.Update(appointment);
                    _context.SaveChanges();
                }
                
            }
            else if (stripeEvent.Type == Events.PaymentIntentPaymentFailed)
            {
                // Ödeme başarısız, gerekli işlemleri gerçekleştirin
                // Bu noktada gelen bilgilere göre ödemenin başarısız olduğunu anlamış olursunuz.
                // Örneğin: var paymentIntentId = stripeEvent.Data.Object.Id;
            }

            return Ok();
        }



        [HttpPost]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] PaymentViewModel model)
        {
            var option = new SessionCreateOptions
            {
                SuccessUrl = $"https://localhost:7144/user/payment/success?id={model.AppointmentId}",
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
                //ViewData["PaymentResponse"] = session.Url;
                return Ok(new PaymentResponse
                {
                    SessionId = session.Id,
                    Url = session.Url

                });
                
            }
            catch (StripeException ex)
            {
                return BadRequest(ex.Message);
                
            }
            
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Success()
        //{
        //    #region Hata
        //    //if (TempData["appointmentId"] != null)
        //    //{
        //    //    var appointmentId = (int)TempData["appointmentId"];
        //    //    TempData.Keep("appointmentId"); // Silinmesini engelle
        //    //    var appointment=    _context.Appointments.Where(x => x.AppointmentId == appointmentId).FirstOrDefault();
        //    //    appointment.Paid = true;
        //    //    _context.Appointments.Update(appointment);
        //    //    _context.SaveChanges();
        //    //}

        //    //if (TempData.ContainsKey("appointmentId"))
        //    //{
        //    //    var appointmentId = (int)TempData["appointmentId"];
        //    //    TempData.Keep("appointmentId"); // Değeri bir sonraki istek için sakla

        //    //    // Şimdi ihtiyacınıza göre appointmentId'yi kullanabilirsiniz
        //    //    var appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == appointmentId);
        //    //    if (appointment != null)
        //    //    {
        //    //        appointment.Paid = true;
        //    //        _context.Appointments.Update(appointment);
        //    //        _context.SaveChanges();
        //    //    }

        //    //    // Gerekirse appointmentId'yi Success view'ına geçirebilirsiniz
        //    //    ViewBag.AppointmentId = appointmentId;

        //    //    return View();
        //    //}

        //    #endregion

        //    var appointment = _context.Appointments.Where(x => x.AppointmentId == id).FirstOrDefault();
        //    if (appointment != null)
        //    {
        //        appointment.Paid = true;
        //        _context.Appointments.Update(appointment);
        //        _context.SaveChanges();
        //    }


        //    return View();
        //}



    
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

      
        //[HttpPost]
        //public IActionResult Success()
        //{
        //    // Form submit edildiğinde gelen appointmentId'yi kullanarak işlem yapabilirsiniz
        //    //var appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == id);
        //    //if (appointment != null)
        //    //{
        //    //    appointment.Paid = true;
        //    //    appointment.BosDolu= false;
        //    //    _context.Appointments.Update(appointment);
        //    //    _context.SaveChanges();
        //    //}

        //    return View();
        //}


        public IActionResult Failure()
        {
            _notifyService.Error("Başarısız");
            return View();
        }




    }
}
