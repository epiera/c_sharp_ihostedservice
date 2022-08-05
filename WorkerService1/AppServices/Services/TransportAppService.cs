using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.ApiServices.Interfaces;
using WorkerService1.AppServices.Interfaces;
using WorkerService1.DTO;
using WorkerService1.Mappers;

namespace WorkerService1.AppServices.Services
{
    public class TransportAppService : ITransportAppService
    {
        private readonly ITransportGamApiService _transportGamApiService;

        public TransportAppService(ITransportGamApiService transportGamApiService)
        {
            _transportGamApiService = transportGamApiService;
        }

        public async Task<string> CreateTransportAsync(TransportExcelDto transportExcelDto)
        {
            var transport = TransportExcelDtoToTransportDtoMappingProfile.Map(transportExcelDto);
            return await _transportGamApiService.PostTransportAsync(transport);
        }
    }
}
