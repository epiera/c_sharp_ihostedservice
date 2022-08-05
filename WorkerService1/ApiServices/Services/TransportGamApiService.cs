using Gam_Api.Client.Interfaces;
using Gam_API.Infra.Cross.Dto;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.ApiServices.Interfaces;

namespace WorkerService1.ApiServices.Services
{
    public class TransportGamApiService : ITransportGamApiService
    {
        private readonly ITransportApiService _transportApiService;

        public TransportGamApiService(ITransportApiService transportApiService)
        {
            _transportApiService = transportApiService;
        }

        public async Task<string> PostTransportAsync(TransportDto transportDto)
        {
            try
            {
                return await _transportApiService.PostTransportAsync(transportDto);
            }
            catch (Exception ex) { Console.WriteLine("Error creating Transport", ex); }

            return "ERROR";
        }
    }
}
