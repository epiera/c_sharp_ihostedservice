using Gam_API.Infra.Cross.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.DTO;

namespace WorkerService1.Mappers
{
    public static class TransportExcelDtoToTransportDtoMappingProfile
    {
        public static TransportDto Map(TransportExcelDto transportExceldto)
        {
            var gamApiEntityTransport = new TransportDto();

            gamApiEntityTransport.Patient = new PatientDto {
                Name = transportExceldto.PatientName,
                Surname = transportExceldto.PatientSurNames,
                Dni = transportExceldto.PatientDni
            };

            gamApiEntityTransport.State = "P";
            gamApiEntityTransport.TransportType = "N";
            gamApiEntityTransport.ContractId = transportExceldto.ContractId;
            gamApiEntityTransport.Observations = transportExceldto.Observations;


            // TODO: Check
            gamApiEntityTransport.TransportReason = "MU";
            gamApiEntityTransport.IsReturn = false;
            gamApiEntityTransport.HasReturn = false;
            gamApiEntityTransport.IsIndividual = false;

            // TODO: Check if is needed -1
            gamApiEntityTransport.StartDate = DateTime.ParseExact($"{transportExceldto.RequestedDate}", "yyyyMMdd HHmmss", System.Globalization.CultureInfo.InvariantCulture);
            gamApiEntityTransport.RequestedDate = DateTime.ParseExact($"{transportExceldto.RequestedDate}", "yyyyMMdd HHmmss", System.Globalization.CultureInfo.InvariantCulture);

            gamApiEntityTransport.PickUpLocation = new LocationDto
            {
                Type = 0,
                Street = transportExceldto.PickUpLocationStreet.Length > 50 ? transportExceldto.PickUpLocationStreet.Substring(0, 50) : transportExceldto.PickUpLocationStreet,
                Province = transportExceldto.PickUpLocationProvince,
                City = transportExceldto.PickUpLocationCity,
                PostalCode = transportExceldto.PickUpLocationPostalCode,
            };

            gamApiEntityTransport.DropOffLocation = new LocationDto
            {
                Type = 1,
                Street = transportExceldto.DropOffLocationStreet.Length > 50 ? transportExceldto.DropOffLocationStreet.Substring(0, 50) : transportExceldto.DropOffLocationStreet,
                Province = transportExceldto.DropOffLocationProvince,
                City = transportExceldto.DropOffLocationCity,
                PostalCode = transportExceldto.DropOffLocationPostalCode,
            };

            return gamApiEntityTransport;
        }
    }
}
