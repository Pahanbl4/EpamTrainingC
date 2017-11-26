using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Interfaces;

namespace Task3.Arguments
{
    public class CallArgsEvent : EventArgs, ICallingArgsEvent
    {

        public int TelephoneNumber { get; private set; }

        public int ObjectTelephoneNumber { get; private set; }

        public Guid Id { get; private set; }


        public CallArgsEvent(int number, int target)
        {
            TelephoneNumber = number;
            ObjectTelephoneNumber = target;
        }

        public CallArgsEvent(int number, int target, Guid id)
        {
            TelephoneNumber = number;
            ObjectTelephoneNumber = target;
            Id = id;
        }
    }

}
