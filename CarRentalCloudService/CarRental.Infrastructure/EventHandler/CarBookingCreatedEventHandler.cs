using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class CarBookingCreatedEventHandler : IEventHandler<CarBookingCreatedEvent>
    {
        public void Handle(CarBookingCreatedEvent handle)
        {
            var carRentalHistoryRepository = RepositoryFactory.Current.Get<ICarRentalHistoryRepository>();
            carRentalHistoryRepository.Add(EventAdapter.ConvertTo(handle));
            carRentalHistoryRepository.UnitOfWork.SaveChanges();
            CarAvailabilityCount(handle.CarModelId);
            CarAvailability(handle);
            PreferredCarModel(handle);
            LeastExpenseCar(handle);
        }

        private void CarAvailabilityCount(Guid carModelId)
        {
            var carAvailablityCount = RepositoryFactory.Current.Get<ICarRentalAvailablityCountView>();
            CarRentalAvailablityCountView carRentalAvaliblityCountUpdate = carAvailablityCount.GetAll().Where(x => x.CarModelId == carModelId).SingleOrDefault();
            if (carRentalAvaliblityCountUpdate != null)
            {
                carRentalAvaliblityCountUpdate.CarCount = carRentalAvaliblityCountUpdate.CarCount - 1;
                carAvailablityCount.Attach(carRentalAvaliblityCountUpdate);
                carAvailablityCount.UnitOfWork.SaveChanges();
            }
        }

        private void CarAvailability(CarBookingCreatedEvent source)
        {
            var carRentalAvailabilityView = RepositoryFactory.Current.Get<ICarRentalAvailablityView>();
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
            var carrentaldetail =
                carRentalRepository.GetAll()
                    .Where(x => x.CarModel.CarModelId == source.CarModelId)
                    .FirstOrDefault();

            if (carrentaldetail != null)
            {
                carRentalAvailabilityView.Add(EventAdapter.CovertToCarRentalAvailablity(source, carrentaldetail.CarModel.ModelName));
            }
            carRentalAvailabilityView.UnitOfWork.SaveChanges();
        }

        private void PreferredCarModel(CarBookingCreatedEvent source)
        {
            var preferredCarModel = RepositoryFactory.Current.Get<IPreferredCarModelView>();
            PreferredCarModelView preferredCarModelUpdate = preferredCarModel.GetAll().Where(x => x.CarModelId == source.CarModelId).SingleOrDefault();
            if (preferredCarModelUpdate != null)
            {
                preferredCarModelUpdate.RentedCount = preferredCarModelUpdate.RentedCount + 1;
                preferredCarModel.Attach(preferredCarModelUpdate);
            }
            else
            {
                var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
                var carrentaldetail =
                    carRentalRepository.GetAll()
                        .Where(x => x.CarModel.CarModelId == source.CarModelId)
                        .FirstOrDefault();

                if (carrentaldetail != null)
                {
                    PreferredCarModelView preferredCarModelInsert = new PreferredCarModelView();
                    preferredCarModelInsert.CarModelId = source.CarModelId;
                    preferredCarModelInsert.CarModelName = carrentaldetail.CarModel.ModelName;
                    preferredCarModelInsert.RentedCount = 1;
                    preferredCarModel.Add(preferredCarModelInsert);
                }
            }

            preferredCarModel.UnitOfWork.SaveChanges();
        }

        private void LeastExpenseCar(CarBookingCreatedEvent handle)
        {
            var leastExpenseCarModelRepository = RepositoryFactory.Current.Get<ILeastExpenseCarModelView>();
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
                var carrentaldetail =
                    carRentalRepository.GetAll()
                        .Where(x => x.CarModel.CarModelId == handle.CarModelId)
                        .FirstOrDefault();

            if (carrentaldetail != null)
            {
                LeastExpenseCarModelView leastExpenseCarModelView = new LeastExpenseCarModelView();
                leastExpenseCarModelView.CarModelId = handle.CarModelId;
                leastExpenseCarModelView.CarModelName = carrentaldetail.CarModel.ModelName;
                leastExpenseCarModelView.Cost = handle.TotalCost;
                leastExpenseCarModelView.RentalId = handle.RentalId;
                leastExpenseCarModelRepository.Add(leastExpenseCarModelView);
                leastExpenseCarModelRepository.UnitOfWork.SaveChanges();
            }
        }
    }
}
