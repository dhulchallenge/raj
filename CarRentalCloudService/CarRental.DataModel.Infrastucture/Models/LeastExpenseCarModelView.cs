using System;
using System.Collections.Generic;

namespace CarRental.DataModel.Infrastucture.Models
{
    public partial class LeastExpenseCarModelView
    {
        public int Id { get; set; }
        public System.Guid RentalId { get; set; }
        public Nullable<System.Guid> CarModelId { get; set; }
        public string CarModelName { get; set; }
        public int Cost { get; set; }
    }
}
