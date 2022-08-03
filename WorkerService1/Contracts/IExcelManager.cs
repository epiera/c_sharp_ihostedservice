using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.DTO;

namespace WorkerService1.Contracts
{
    public interface IExcelManager
    {
        IEnumerable<TransportExcelDto> GetTransportsExcel(string excelFile);
    }
}
