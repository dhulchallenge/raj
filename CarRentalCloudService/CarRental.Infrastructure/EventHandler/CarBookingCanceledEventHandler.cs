using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Aggregate.Repository;
using CarRental.Infrastructure.Domain.Repository;
using CarRental.Infrastructure.EventHandler.Adapter;
using CarRental.Infrastructure.Events;
using CarRental.Infrastructure.Utils;

namespace CarRental.Infrastructure.EventHandler
{
    public class CarBookingCanceledEventHandler : IEventHandler<CarBookingCanceledEvent>
    {
        public void Handle(CarBookingCanceledEvent handle)
        {
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
            CarRentalDetail carRentalDetail = carRentalRepository.GetAll().Where(x => x.RentalId == handle.RentalId).FirstOrDefault();
            if (carRentalDetail != null)
            {
                var carRentalRentalHistory = RepositoryFactory.Current.Get<ICarRentalHistoryRepository>();
                CarRentalDetailsHistory carRentalDetailsHistory =
                    EventAdapter.ConvertToRentalDetailsHistory(carRentalDetail, typeof(CarBookingCanceledEvent).Name);
                carRentalRentalHistory.Add(carRentalDetailsHistory);
                carRentalRentalHistory.UnitOfWork.SaveChanges();
                CarAvailabilityIncreamentCount(carRentalDetailsHistory.CarModelId);
                CarAvailability(carRentalDetailsHistory);
            }
        }

        private void CarAvailabilityIncreamentCount(Guid carModelId)
        {
            var carAvailablityCount = RepositoryFactory.Current.Get<ICarRentalAvailablityCountView>();
            CarRentalAvailablityCountView carRentalAvaliblityCountUpdate = carAvailablityCount.GetAll().Where(x => x.CarModelId == carModelId).FirstOrDefault();
            if (carRentalAvaliblityCountUpdate != null)
            {
                carRentalAvaliblityCountUpdate.CarCount = carRentalAvaliblityCountUpdate.CarCount + 1;
                carAvailablityCount.Attach(carRentalAvaliblityCountUpdate);
                carAvailablityCount.UnitOfWork.SaveChanges();
            }
        }

        private void CarAvailability(CarRentalDetailsHistory source)
        {
            var carRentalAvailabilityView = RepositoryFactory.Current.Get<ICarRentalAvailablityView>();
            CarRentalAvailablityView carRentalAvailablityRemove = carRentalAvailabilityView.GetAll().Where(x => x.RentalId == source.RentalId).FirstOrDefault();
            carRentalAvailabilityView.Delete(carRentalAvailablityRemove);
            carRentalAvailabilityView.UnitOfWork.SaveChanges();
        }
    }
}
