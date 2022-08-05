using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.DTO
{
    public class TransportExcelDto
    {
        public string PatientName { get; set; }
        public string PatientSurNames { get; set; }
        public string PatientDni { get; set; }
        public string PatientPhone { get; set; }
        public string PickUpLocationStreet { get; set; }
        public string PickUpLocationCity { get; set; }
        public string PickUpLocationProvince { get; set; }
        public string PickUpLocationPostalCode { get; set; }
        public string DropOffLocationStreet { get; set; }
        public string DropOffLocationCity { get; set; }
        public string DropOffLocationProvince { get; set; }
        public string DropOffLocationPostalCode { get; set; }
        public string Observations { get; set; }
        public DateTime? RequestedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ContractId { get; set; }
    }
}
