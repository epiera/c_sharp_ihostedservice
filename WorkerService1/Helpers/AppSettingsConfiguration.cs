using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Helpers
{
    public class AppSettingsConfiguration
    {
        public class TransportAppSettingsConfiguration
        {
            public string Token { get; set; }
            public string MuVendorId { get; set; }
            public string MuSupplierId { get; set; }
            public string ClientName { get; set; }
            public string ContractId { get; set; }
            public string TransportOriginCode { get; set; }
            public string Sender { get; set; }
            public string Host { get; set; }
            public string Pwd { get; set; }
            public int Port { get; set; }
            public string SslProtocol { get; set; }
            public Dictionary<string, string> MailTo { get; set; }
        }
    }
}
