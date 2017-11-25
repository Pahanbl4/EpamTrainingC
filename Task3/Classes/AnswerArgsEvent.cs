using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
   public class AnswerArgsEvent:EventArgs,ICallingArgsEvent
    {
        public int TelephoneNumber { get; private set; }

        public int ObjectTelephoneNumber { get; private set; }

        public Guid Id { get; private set; }

        public StatusCall StatusInCall;


        public AnswerArgsEvent(int number, int target, StatusCall status)
        {
            TelephoneNumber = number;
            ObjectTelephoneNumber = target;
            StatusInCall = status;
        }

        public AnswerArgsEvent(int number, int target, StatusCall status, Guid id)
        {
            TelephoneNumber = number;
            ObjectTelephoneNumber = target;
            StatusInCall = status;
            Id = id;
        }
    }
}
