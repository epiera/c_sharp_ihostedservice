using Gam_API.Infra.Cross.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.ApiServices.Interfaces
{
    public interface ITransportGamApiService
    {
        Task<string> PostTransportAsync(TransportDto transport);
    }
}
