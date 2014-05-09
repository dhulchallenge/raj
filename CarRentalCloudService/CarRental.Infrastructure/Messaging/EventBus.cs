using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.Events;
using CarRental.Infrastructure.Utils;

namespace CarRental.Infrastructure.Messaging
{
    public class EventBus : IEventBus
    {
        public void Publish<T>(T @event) where T : Event
        {
            var _eventHandlerFactory = HandlerFactory.Current.Get<IEventHandlerFactory>();
            var handlers = _eventHandlerFactory.GetHandlers<T>();
            handlers.Handle(@event);

        }
    }
}
