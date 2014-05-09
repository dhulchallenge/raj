using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Aggregate;
using CarRental.Infrastructure.Aggregate.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.Commands.Adapter;
using CarRental.Infrastructure.Events;
using CarRental.Infrastructure.Messaging;
using CarRental.Infrastructure.Utils;

namespace CarRental.Infrastructure.CommandHandlers
{
    public class CarBookingCommandHandler : ICommandHandler<CarBookingCommand>
    {
        private List<Event> events;
        public CarBookingCommandHandler()
        {
            events = new List<Event>();
        }

        public void Execute(CarBookingCommand command)
        {
            if (command != null)
            {
                CarRental.Infrastructure.Domain.CarRentalDetail carRentalDetail = new CarRental.Infrastructure.Domain.CarRentalDetail(command.RentalId, command.CarModelId, command.CarRentalEndDate, command.CarRentalStartDate, command.LocationId, command.TotalCost,
                command.DriverName, command.LicenseneNumber, command.ContactNumber, command.EmailId, command.Address);
                var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
                carRentalRepository.Add(CommandAdapter.ConvertTo(carRentalDetail));
                carRentalRepository.UnitOfWork.SaveChanges();
                publishEvent(carRentalDetail);
            }
        }

        private void publishEvent(AggregateRoot aggregateRoot)
        {
            var eventBus = EventFactory.Current.Get<IEventBus>();
            var uncommittedChanges = aggregateRoot.GetUncommittedChanges();
            foreach (var @event in uncommittedChanges)
            {
                events.Add(@event);
            }
            foreach (var @event in uncommittedChanges)
            {
                var desEvent = Converter.ChangeTo(@event, @event.GetType());
                eventBus.Publish<CarBookingCreatedEvent>(desEvent);
            }
        }

    }

}
