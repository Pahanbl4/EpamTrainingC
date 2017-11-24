using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public class CallArgsEvent : EventArgs, ICallingArgsEvent
    {

        public int TelephoneNumber { get; private set; }

        public int ObjectTelephoneNumber { get; private set; }

        public int Id { get; private set; }


        public CallArgsEvent(int number, int target)
        {
            TelephoneNumber = number;
            ObjectTelephoneNumber = target;
        }

        public CallArgsEvent(int number, int target, int id)
        {
            TelephoneNumber = number;
            ObjectTelephoneNumber = target;
            Id = id;
        }
    }

}
