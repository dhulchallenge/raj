using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Commands
{
    public class CarBookingChangingCommand : Command
    {
        public System.Guid RentalId { get; set; }
        public DateTime RentalEndDate { get; set; }

        public CarBookingChangingCommand(Guid rentalId, DateTime rentalEndDate)
            : base(rentalId)
        {
            this.RentalId = rentalId;
            this.RentalEndDate = rentalEndDate;
        }
    }
}
