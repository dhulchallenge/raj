using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Events
{
    public class Event : IEvent
    {
        public Guid Id { get; private set; }
    }
}
