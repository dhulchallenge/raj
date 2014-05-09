﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.DataModel.Infrastucture.Models;
using CarRental.Infrastructure.Aggregate;
using CarRental.Infrastructure.Aggregate.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.Events;
using CarRental.Infrastructure.Messaging;
using CarRental.Infrastructure.Utils;

namespace CarRental.Infrastructure.CommandHandlers
{
    public class CarBookingCancelingCommandHandler : ICommandHandler<CarBookingCancelingCommand>
    {
        private List<Event> events;

        public CarBookingCancelingCommandHandler()
        {
            events = new List<Event>();
        }

        public void Execute(CarBookingCancelingCommand command)
        {
            var carRentalRepository = RepositoryFactory.Current.Get<ICarRentalRepository>();
            CarRentalDetail carRentalDetail = carRentalRepository.GetAll().Where(x => x.RentalId == command.RentalId).FirstOrDefault();
            if (carRentalDetail != null)
            {
                carRentalDetail.Status = command.Status;
                carRentalRepository.Attach(carRentalDetail);
                carRentalRepository.UnitOfWork.SaveChanges();
                var aggregate = new CarRental.Infrastructure.Domain.CarRentalDetail(carRentalDetail.RentalId,
                    carRentalDetail.Status);
                publishEvent(aggregate);
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
                eventBus.Publish<CarBookingCanceledEvent>(desEvent);
            }
        }
    }
}
