using System;
using System.Collections.Generic;

namespace CarRental.DataModel.Infrastucture.Models
{
    public partial class CarRentalAvailablityView
    {
        public int AvailablityId { get; set; }
        public System.Guid RentalId { get; set; }
        public Nullable<System.Guid> CarModelId { get; set; }
        public string CarModelName { get; set; }
        public Nullable<System.DateTime> CarRentalStartDate { get; set; }
        public Nullable<System.DateTime> CarRentalEndDate { get; set; }
        public Nullable<System.Guid> LocationId { get; set; }
        public string LicenseneNumber { get; set; }
        public Nullable<int> ContactNumber { get; set; }
        public string EmailId { get; set; }
    }
}
