using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Workers
{
    public interface IExcelReaderWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
