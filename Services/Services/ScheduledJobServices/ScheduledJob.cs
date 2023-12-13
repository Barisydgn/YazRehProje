using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.ScheduledJobServices
{
    public class ScheduledJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ScheduledJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int suAnkiSaat = DateTime.Now.Hour;
                int suAnkiDakika = DateTime.Now.Minute;
                int hedefSaat = 00;
                int hedefDakika = 00;
                // Belirli bir saatte işlemi gerçekleştir
                if(suAnkiSaat == hedefSaat && suAnkiDakika == hedefDakika) // Saat 00:00'da
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();
                       await  scopedService.DoSomethingAsync();
                    }
                }

                // 24 saat bekleyin ve döngüyü yeniden başlatın
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
