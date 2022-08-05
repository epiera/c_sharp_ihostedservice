using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.DTO;

namespace WorkerService1.Contracts
{
    public class ExcelManager : IExcelManager
    {
        public List<TransportExcelDto> GetTransportExcelList(string excelFile)
        {
            List<TransportExcelDto> transports = new List<TransportExcelDto>();

            IXLWorkbook workBook = new XLWorkbook(excelFile);
            IXLWorksheet workSheet = workBook.Worksheet(1);

            foreach (IXLRow row in workSheet.RowsUsed().Skip(1)) // Skip first row (header)
            {
                TransportExcelDto transportExcelDto = new TransportExcelDto();
                transportExcelDto.PatientName = row.Cell(1).GetString();
                transportExcelDto.PatientSurNames = row.Cell(2).GetString();
                transportExcelDto.PatientDni = row.Cell(3).GetString();
                transportExcelDto.PatientPhone = row.Cell(4).GetString();
                transportExcelDto.PickUpLocationStreet = row.Cell(5).GetString();
                transportExcelDto.PickUpLocationCity = row.Cell(6).GetString();
                transportExcelDto.PickUpLocationProvince = row.Cell(7).GetString();
                transportExcelDto.PickUpLocationPostalCode = row.Cell(8).GetString();
                transportExcelDto.DropOffLocationStreet = row.Cell(9).GetString();
                transportExcelDto.DropOffLocationCity = row.Cell(10).GetString();
                transportExcelDto.DropOffLocationProvince = row.Cell(11).GetString();
                transportExcelDto.DropOffLocationPostalCode = row.Cell(12).GetString();
                transportExcelDto.Observations = row.Cell(13).GetString();
                transportExcelDto.RequestedDate = row.Cell(14).GetDateTime();
                transportExcelDto.ReturnDate = row.Cell(15).GetDateTime();
                transportExcelDto.ContractId = row.Cell(16).GetString();


                transports.Add(transportExcelDto);
            }

            return transports;
        }
    }
}
