using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.EventHandler;
using CarRental.Infrastructure.Events;

namespace CarRental.Infrastructure.Utils
{
    public interface  IEventHandlerFactory
    {
        IEventHandler<T> GetHandlers<T>() where T : Event;
    }
}
