using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.AppServices.Interfaces;
using WorkerService1.Contracts;
using WorkerService1.DTO;

namespace WorkerService1.Workers
{
    public class ExcelReaderWorker : IExcelReaderWorker
    {

        private readonly IConfiguration _configuration;
        //private readonly IServiceProvider _serviceProvider;
        private readonly ITransportAppService _transportAppService;

        public ExcelReaderWorker(IConfiguration configuration, ITransportAppService transportAppService)
        {
            _configuration = configuration;
            _transportAppService = transportAppService;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            var path = _configuration.GetValue<string>("RutaFicherosGenericos");

            Console.WriteLine("Getting excel files...");
            // Get files from directory
            IEnumerable<string> excelFiles = Directory.GetFiles(path)
                    .Where(file => new string[] { ".xlsx" }
                    .Contains(Path.GetExtension(file)));


            ExcelManager excelManager = new ExcelManager();
            var transportsExcelDto = new List<TransportExcelDto>();


            Console.WriteLine("Getting tranports from excel files...");
            // Get all transportsExcelDto in all files
            foreach (string excelFile in excelFiles)
            {
                transportsExcelDto.AddRange(excelManager.GetTransportExcelList(excelFile));
            }


            Console.WriteLine("Creating Transports...");
            foreach (var transportExceltDto in transportsExcelDto)
            {
                //Transport transport = TransportExcelDtoToTransportMappingProfile.Map(transporExceltDto);
                var transport = await CreateTransportAsync(transportExceltDto);
            }

        }
        public async Task<string> CreateTransportAsync(TransportExcelDto transportExcelDto)
        {
            try
            {
                return await _transportAppService.CreateTransportAsync(transportExcelDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating Transport", ex);
            }
            return "ERROR";
        }
    }
}
