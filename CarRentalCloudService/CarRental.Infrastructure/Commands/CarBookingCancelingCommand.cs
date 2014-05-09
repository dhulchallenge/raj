using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Commands
{
    public class CarBookingCancelingCommand : Command
    {
        public System.Guid RentalId { get; set; }
        public string Status { get; set; }

        public CarBookingCancelingCommand(Guid rentalId, string status) : base(rentalId)
        {
            this.RentalId = rentalId;
            this.Status = status;
        }
    }
}
