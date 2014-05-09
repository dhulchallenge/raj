using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Domain.Repository;

namespace CarRental.DataModel
{
    public class CarModel : Repository<CarRental.DataModel.Infrastucture.Models.CarModel>, ICarModel
    {
        public CarModel() : base(new CarRentalDatabaseContext())
        {
        }

        public new IQueryable<Infrastucture.Models.CarModel> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public new IEnumerable<Infrastucture.Models.CarModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Infrastucture.Models.CarModel> Find(System.Linq.Expressions.Expression<Func<Infrastucture.Models.CarModel, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Infrastucture.Models.CarModel Single(System.Linq.Expressions.Expression<Func<Infrastucture.Models.CarModel, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Infrastucture.Models.CarModel First(System.Linq.Expressions.Expression<Func<Infrastucture.Models.CarModel, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(Infrastucture.Models.CarModel entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Infrastucture.Models.CarModel entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Infrastucture.Models.CarModel entity)
        {
            throw new NotImplementedException();
        }

        public void Attach(Infrastucture.Models.CarModel entity, EntityStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
