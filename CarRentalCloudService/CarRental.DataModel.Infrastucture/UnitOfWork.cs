using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataModel.Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
        public IObjectContextAdapter _ObjectContextAdapter { get; set; }


        public void SaveChanges()
        {
            try
            {
                int j = _ObjectContextAdapter.ObjectContext.SaveChanges();
            }
            catch (OptimisticConcurrencyException oce)
            {

            }
            catch (DataException)
            {
                throw;
            }
        }

        public void Dispose()
        {
            if (_ObjectContextAdapter != null)
                _ObjectContextAdapter.ObjectContext.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
