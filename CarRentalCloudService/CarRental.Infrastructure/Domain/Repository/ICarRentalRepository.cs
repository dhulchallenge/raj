using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture;
using CarRental.DataModel.Infrastucture.Models;

namespace CarRental.Infrastructure.Aggregate.Repository
{
    public interface ICarRentalRepository : IRepository<CarRentalDetail>
    {
    }
}
