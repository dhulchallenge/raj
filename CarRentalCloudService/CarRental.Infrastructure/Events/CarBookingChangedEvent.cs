using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Events
{
    public class CarBookingChangedEvent : Event
    {
        public System.Guid RentalId { get; set; }
        public System.DateTime CarRentalEndDate { get; set; }

        public CarBookingChangedEvent(Guid rentalId, DateTime carRentalEndDate)
        {
            this.RentalId = rentalId;
            this.CarRentalEndDate = carRentalEndDate;
        }
    }
}
