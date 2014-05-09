using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalWebRole.Controllers.Contracts
{
    public class CarRental
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
    }
}