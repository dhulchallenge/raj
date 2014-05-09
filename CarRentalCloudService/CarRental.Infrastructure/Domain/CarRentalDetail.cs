﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.Aggregate;
using CarRental.Infrastructure.Events;

namespace CarRental.Infrastructure.Domain
{
    public class CarRentalDetail : AggregateRoot, IHandle<CarBookingCreatedEvent>, IHandle<CarBookingChangedEvent>,IHandle<CarBookingCanceledEvent>
    {
        public System.Guid RentalId { get; set; }
        public System.Guid CarModelId { get; set; }
        public System.DateTime CarRentalStartDate { get; set; }
        public System.DateTime CarRentalEndDate { get; set; }
        public System.Guid LocationId { get; set; }
        public string Status { get; set; }
        public int TotalCost { get; set; }
        public string DriverName { get; set; }
        public string LicenseneNumber { get; set; }
        public int ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }

        public CarRentalDetail(Guid RentalId, System.Guid CarModelId,
            System.DateTime CarRentalEndDate, System.DateTime CarRentalStartDate, System.Guid LocationId,
            int TotalCost, string DriverName, string LicenseneNumber, int ContactNumber, string EmailId, string Address)
        {
            ApplyChange(new CarBookingCreatedEvent(RentalId, CarModelId, CarRentalEndDate, CarRentalStartDate, LocationId, TotalCost, DriverName, LicenseneNumber, ContactNumber, EmailId, Address));
        }

        public CarRentalDetail(Guid RentalId, string Status)
        {
            ApplyChange(new CarBookingCanceledEvent(RentalId, Status));
        }

        public CarRentalDetail(Guid RentalId, System.DateTime CarRentalEndDate)
        {
            ApplyChange(new CarBookingChangedEvent(RentalId, CarRentalEndDate));
        }

        public void Handle(CarBookingCreatedEvent e)
        {
            this.RentalId = e.RentalId;
            this.CarModelId = e.CarModelId;
            this.CarRentalEndDate = e.CarRentalEndDate;
            this.CarRentalStartDate = e.CarRentalStartDate;
            this.LocationId = e.LocationId;
            this.TotalCost = e.TotalCost;
            this.DriverName = e.DriverName;
            this.LicenseneNumber = e.LicenseneNumber;
            this.ContactNumber = e.ContactNumber;
            this.EmailId = e.EmailId;
            this.Address = e.Address;
            this.Status = e.Status;
        }

        public void Handle(CarBookingCanceledEvent e)
        {
            this.RentalId = e.RentalId;
            this.Status = e.Status;
        }

        public void Handle(CarBookingChangedEvent e)
        {
            this.RentalId = e.RentalId;
            this.CarRentalStartDate = e.CarRentalEndDate;
        }
    }
}
