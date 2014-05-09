using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Events
{
    public class CarBookingCanceledEvent : Event
    {
        public System.Guid RentalId { get; set; }
        public string Status { get; set; }

        public CarBookingCanceledEvent(Guid rentalId, string status)
        {
            this.RentalId = rentalId;
            this.Status = status;
        }
    }
}
