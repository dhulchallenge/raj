using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Events;

namespace CarRental.Infrastructure.EventHandler.Adapter
{
    public static class EventAdapter
    {
        public static CarRentalDetailsHistory ConvertTo(CarBookingCreatedEvent source)
        {
            CarRental.DataModel.Infrastucture.Models.CarRentalDetailsHistory rentalCarHistoryDetails = new CarRental.DataModel.Infrastucture.Models.CarRentalDetailsHistory();
            rentalCarHistoryDetails.RentalId = source.RentalId;
            rentalCarHistoryDetails.CarModelId = source.CarModelId;
            rentalCarHistoryDetails.CarRentalStartDate = source.CarRentalStartDate;
            rentalCarHistoryDetails.CarRentalEndDate = source.CarRentalEndDate;
            rentalCarHistoryDetails.LocationId = source.LocationId;
            rentalCarHistoryDetails.TotalCost= source.TotalCost;
            rentalCarHistoryDetails.Status = typeof(CarBookingCreatedEvent).Name;
            rentalCarHistoryDetails.DriverName = source.DriverName;
            rentalCarHistoryDetails.LicenseneNumber = source.LicenseneNumber;
            rentalCarHistoryDetails.ContactNumber = source.ContactNumber;
            rentalCarHistoryDetails.EmailId = source.EmailId;
            rentalCarHistoryDetails.Address = source.Address;
            rentalCarHistoryDetails.CreatedDate = DateTime.Now;
            
            return rentalCarHistoryDetails;
        }

        public static CarRentalDetailsHistory ConvertToRentalDetailsHistory(CarRentalDetail source , string typeOfEvent)
        {
            CarRentalDetailsHistory rentalCarHistoryDetails = new CarRentalDetailsHistory();
            rentalCarHistoryDetails.Address = source.Address;
            rentalCarHistoryDetails.RentalId = source.RentalId;
            rentalCarHistoryDetails.CarModelId = source.CarModelId;
            rentalCarHistoryDetails.CarRentalStartDate = source.CarRentalStartDate;
            rentalCarHistoryDetails.CarRentalEndDate = source.CarRentalEndDate;
            rentalCarHistoryDetails.LocationId = source.LocationId;
            rentalCarHistoryDetails.TotalCost = source.TotalCost;
            rentalCarHistoryDetails.DriverName = source.DriverName;
            rentalCarHistoryDetails.LicenseneNumber = source.LicenseneNumber;
            rentalCarHistoryDetails.ContactNumber = source.ContactNumber;
            rentalCarHistoryDetails.EmailId = source.EmailId;
            rentalCarHistoryDetails.Status = source.Status;
            rentalCarHistoryDetails.CreatedDate = DateTime.Now;
            rentalCarHistoryDetails.Status = typeOfEvent;
            return rentalCarHistoryDetails;
        }

        public static CarRentalAvailablityView CovertToCarRentalAvailablity(CarBookingCreatedEvent source, string carModelName)
        {
            CarRentalAvailablityView CarAvailablity = new CarRentalAvailablityView();
            CarAvailablity.RentalId = source.RentalId;
            CarAvailablity.CarModelId = source.CarModelId;
            CarAvailablity.CarRentalStartDate = source.CarRentalStartDate;
            CarAvailablity.CarRentalEndDate = source.CarRentalEndDate;
            CarAvailablity.LocationId = source.LocationId;
            CarAvailablity.LicenseneNumber = source.LicenseneNumber;
            CarAvailablity.ContactNumber = source.ContactNumber;
            CarAvailablity.EmailId = source.EmailId;
            CarAvailablity.CarModelName = carModelName;
            return CarAvailablity;
        }

        public static CarRentalAvailablityView CovertToCarRentalAvailablityView(CarRentalDetailsHistory source)
        {
            CarRentalAvailablityView CarAvailablity = new CarRentalAvailablityView();
            
            CarAvailablity.RentalId = source.RentalId;
            CarAvailablity.CarModelId = source.CarModelId;
            CarAvailablity.CarRentalStartDate = source.CarRentalStartDate;
            CarAvailablity.CarRentalEndDate = source.CarRentalEndDate;
            CarAvailablity.LocationId = source.LocationId;
            CarAvailablity.LicenseneNumber = source.LicenseneNumber;
            CarAvailablity.ContactNumber = source.ContactNumber;
            CarAvailablity.EmailId = source.EmailId;
            return CarAvailablity;
        }
    }
}
