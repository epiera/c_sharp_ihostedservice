using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.DTO;

namespace WorkerService1.AppServices.Interfaces
{
    public interface ITransportAppService
    {
        Task<string> CreateTransportAsync(TransportExcelDto transportExcelDto);
    }
}
