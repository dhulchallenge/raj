using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Aggregate.Repository;

namespace CarRental.DataModel
{
    public class CarRentalRepository : Repository<CarRentalDetail>, ICarRentalRepository
    {
        public CarRentalRepository()
            : base(new CarRentalDatabaseContext())
        {
        }
    }
}
