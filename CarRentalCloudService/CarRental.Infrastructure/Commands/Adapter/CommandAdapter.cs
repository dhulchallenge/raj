using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture.Models;

namespace CarRental.Infrastructure.Commands.Adapter
{
    public static class CommandAdapter
    {
        public static CarRentalDetail ConvertTo(CarRental.Infrastructure.Domain.CarRentalDetail source)
        {
            CarRental.DataModel.Infrastucture.Models.CarRentalDetail carRentalDetail = new CarRental.DataModel.Infrastucture.Models.CarRentalDetail();
            carRentalDetail.Address = source.Address;
            carRentalDetail.RentalId = source.RentalId;
            carRentalDetail.CarModelId = source.CarModelId;
            carRentalDetail.CarRentalStartDate = source.CarRentalStartDate;
            carRentalDetail.CarRentalEndDate = source.CarRentalEndDate;
            carRentalDetail.LocationId = source.LocationId;
            carRentalDetail.TotalCost = source.TotalCost;
            carRentalDetail.DriverName = source.DriverName;
            carRentalDetail.LicenseneNumber = source.LicenseneNumber;
            carRentalDetail.ContactNumber = source.ContactNumber;
            carRentalDetail.EmailId = source.EmailId;
            carRentalDetail.Status = "Active";
            return carRentalDetail;
        }
    }
}
