using System;
using System.Collections.Generic;

namespace CarRental.DataModel.Infrastucture.Models
{
    public partial class PreferredCarModelView
    {
        public int Id { get; set; }
        public System.Guid CarModelId { get; set; }
        public string CarModelName { get; set; }
        public int RentedCount { get; set; }
    }
}
