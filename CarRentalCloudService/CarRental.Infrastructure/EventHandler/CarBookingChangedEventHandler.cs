using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Aggregate.Repository;
using CarRental.Infrastructure.Commands.Adapter;
using CarRental.Infrastructure.Domain.Repository;
using CarRental.Infrastructure.EventHandler.Adapter;
using CarRental.Infrastructure.Events;
using CarRental.Infrastructure.Utils;

namespace CarRental.Infrastructure.EventHandler
{
    public class CarBookingChangedEventHandler : IEventHandler<CarBookingChangedEvent>
    {
        public void Handle(CarBookingChangedEvent handle)
        {
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
            CarRentalDetail carRentalDetail = carRentalRepository.GetAll().Where(x => x.RentalId == handle.RentalId).FirstOrDefault();
            if (carRentalDetail != null)
            {
                var carRentalRentalHistory = RepositoryFactory.Current.Get<ICarRentalHistoryRepository>();
                carRentalRentalHistory.Add(EventAdapter.ConvertToRentalDetailsHistory(carRentalDetail,
                    typeof (CarBookingChangedEvent).Name));
                carRentalRentalHistory.UnitOfWork.SaveChanges();
                CarAvailabilityChanged(handle);
            }
        }

        private void CarAvailabilityChanged(CarBookingChangedEvent source)
        {
            var carRentalAvailabilityView = RepositoryFactory.Current.Get<ICarRentalAvailablityView>();
            CarRentalAvailablityView carRentalAvailablityUpdate = carRentalAvailabilityView.GetAll().Where(x => x.RentalId == source.RentalId).FirstOrDefault();
            if (carRentalAvailablityUpdate != null)
            {
                carRentalAvailablityUpdate.CarRentalEndDate = source.CarRentalEndDate;
                carRentalAvailabilityView.Attach(carRentalAvailablityUpdate);
                carRentalAvailabilityView.UnitOfWork.SaveChanges();
            }
        }
    }
}
