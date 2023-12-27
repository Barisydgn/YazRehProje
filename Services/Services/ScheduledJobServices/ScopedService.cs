using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ScheduledJobServices
{
    public class ScopedService : IScopedService
    {
        private readonly YazContext _context;

        public ScopedService(YazContext context)
        {
            _context = context;
        }

        public async Task DoSomethingAsync()
        {
            GunlukRandevuOlustur();
            await Task.CompletedTask;
        }
        public void GunlukRandevuOlustur()
        {
            // Her gün belirli bir saatte çalıştığınızı düşünerek, şu anki tarih ve saat bilgisini alın
            DateTime simdikiZaman = DateTime.Now;

            // Eğer belirli bir saatte çalışmasını istiyorsanız, aşağıdaki satırı güncelleyebilirsiniz
            DateTime olusturulacakTarih = new DateTime(simdikiZaman.Year, simdikiZaman.Month, simdikiZaman.Day, 1, 0, 0);

            // Eğer bugün için daha önce randevular oluşturulmuşsa, tekrar oluşturmamak için kontrol yapısı
            if (!_context.Appointments.Any(r => r.AppointmentDate.Date == olusturulacakTarih.Date))
            {
                List<Appointment> randevular = RandevuOlustur(olusturulacakTarih, 8);
                _context.Appointments.AddRange(randevular);
                _context.SaveChanges();
            }
        }

        private List<Appointment> RandevuOlustur(DateTime tarih, int randevuSayisi)
        {
            DateTime saat;
            List<Appointment> randevuListesi = new List<Appointment>();
            tarih = DateTime.Now.AddDays(7);

            for (int i = 0; i < 8; i++)
            {
                Appointment randevu = new Appointment
                {
                    AppointmentDate = tarih.AddHours(i + 10), // Örneğin, 9'dan başlayarak her saat için bir randevu
                    AppointmentTime =TimeSpan.FromHours(10 + i),
                    StudentName = " ",
                    StudentSurname = " ",
                    BosDolu = true,
                    Paid=false
                };

                randevuListesi.Add(randevu);
            }
            return randevuListesi;
        }
    }
}
