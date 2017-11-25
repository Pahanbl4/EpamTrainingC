using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Interfaces;

namespace Task3.Classes
{
    public class EndCallArgsEvent : EventArgs, ICallingArgsEvent
    {
        public int TelephoneNumber { get; private set; }

        public int ObjectTelephoneNumber { get; private set; }

        public Guid Id { get; private set; }

        public EndCallArgsEvent(Guid id, int number)
        {
            Id = id;
            TelephoneNumber = number;
        }
    }
}
