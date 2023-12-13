using Entities.Models;
using Repositories.Context;
using System.Timers;

namespace YazRehProje.Extensions
{
    public class CreatedAppointment
    {
        #region Otomatik Randevu1
        //private readonly YazContext _context;

        //public CreatedAppointment(YazContext context)
        //{
        //    _context = context;
        //}

        //private System.Threading.Timer timer;
        //public void Start()
        //{
        //    DateTime now = DateTime.Now;
        //    DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);

        //    if (now > scheduledTime)
        //    {
        //        scheduledTime = scheduledTime.AddDays(1);
        //    }

        //    double interval = (scheduledTime - now).TotalMilliseconds;

        //    timer = new System.Threading.Timer(TimerElapsed, null, Convert.ToInt32(interval), Timeout.Infinite);
        //}

        //private void TimerElapsed(object state)
        //{
        //    // Her gün 8 boş randevu oluştur
        //    for (int i = 0; i < 8; i++)
        //    {
        //        var randevu = new Appointment
        //        {
        //            AppointmentDate = DateTime.Today.AddDays(i),
        //            AppointmentTime=TimeSpan.FromHours(i+7),
        //            BosDolu = true
        //        };

        //        _context.Appointments.Add(randevu);
        //    }

        //    _context.SaveChanges();

        //    // Bir sonraki gün için timer'ı ayarla
        //    DateTime now = DateTime.Now;
        //    DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0).AddDays(1);
        //    double interval = (scheduledTime - now).TotalMilliseconds;

        //    timer.Change(Convert.ToInt32(interval), Timeout.Infinite);
        //} 
        #endregion

        #region Randevu2
        //private readonly YazContext _context;

        //public AppointmentServices(YazContext context)
        //{
        //    _context = context;
        //}

        //public void GunlukRandevuOlustur()
        //{
        //    // Her gün belirli bir saatte çalıştığınızı düşünerek, şu anki tarih ve saat bilgisini alın
        //    DateTime simdikiZaman = DateTime.Now;

        //    // Eğer belirli bir saatte çalışmasını istiyorsanız, aşağıdaki satırı güncelleyebilirsiniz
        //    DateTime olusturulacakTarih = new DateTime(simdikiZaman.Year, simdikiZaman.Month, simdikiZaman.Day, 7, 0, 0);

        //    // Eğer bugün için daha önce randevular oluşturulmuşsa, tekrar oluşturmamak için kontrol yapısı
        //    if (_context.Appointments.Any(r => r.AppointmentDate.Date == olusturulacakTarih.Date))
        //    {
        //        List<Appointment> randevular = RandevuOlustur(olusturulacakTarih, 8);
        //        _context.Appointments.AddRange(randevular);
        //        _context.SaveChanges();
        //    }
        //}

        //private List<Appointment> RandevuOlustur(DateTime tarih, int randevuSayisi)
        //{
        //    List<Appointment> randevuListesi = new List<Appointment>();

        //    for (int i = 0; i < 8; i++)
        //    {
        //        Appointment randevu = new Appointment
        //        {
        //            AppointmentDate = tarih.AddHours(i + 10) // Örneğin, 9'dan başlayarak her saat için bir randevu
        //        };

        //        randevuListesi.Add(randevu);
        //    }
        //    return randevuListesi;
        //} 
        #endregion

    }
}
