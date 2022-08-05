using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Workers;

namespace WorkerService1
{
    public class ExcelReaderBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ExcelReaderBackgroundService(IServiceProvider serviceProvider) =>
            (_serviceProvider) = (serviceProvider);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
            while (await timer.WaitForNextTickAsync())
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    await scope.ServiceProvider.GetRequiredService<IExcelReaderWorker>()
                       .DoWork(stoppingToken);
                }
            }

        }
    }
}
