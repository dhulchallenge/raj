﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Domain.Repository;

namespace CarRental.DataModel
{
    public class CarRentalAvailablity : Repository<CarRentalAvailablityView>,ICarRentalAvailablityView
    {
        public CarRentalAvailablity() : base(new CarRentalDatabaseContext())
        {
        }
    }
}
