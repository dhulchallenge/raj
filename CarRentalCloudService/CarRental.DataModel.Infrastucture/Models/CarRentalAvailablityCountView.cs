using System;
using System.Collections.Generic;

namespace CarRental.DataModel.Infrastucture.Models
{
    public partial class CarRentalAvailablityCountView
    {
        public int AvailablityId { get; set; }
        public System.Guid CarModelId { get; set; }
        public string CarModelName { get; set; }
        public int CarCount { get; set; }
    }
}
