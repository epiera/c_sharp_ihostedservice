using Serilog;
using WorkerService1.Contracts;
using WorkerService1.DTO;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly IConfiguration _configuration;

        public Worker(IConfiguration configuration)
        {
            _configuration = configuration;
            
            // To use Serilog....
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Log.Information("Worker running at: {Now}", DateTimeOffset.Now);

                // Get path from appsettings.json
                var path = _configuration.GetValue<string>("RutaFicherosGenericos");

                // Get files from directory
                IEnumerable<string> excelFiles = Directory.GetFiles(path)
                        .Where(file => new string[] { ".xlsx" }
                        .Contains(Path.GetExtension(file)));             


                ExcelManager excelManager = new ExcelManager();
                IEnumerable<TransportExcelDto> transports;

                foreach (string excelFile in excelFiles)
                {
                    transports = excelManager.GetTransportsExcel(excelFile);
                }


                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}