using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;

namespace Task3.Bylling
{
   public class CallRecords
    {
        public CallTypes CallType { get; private set; }
        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime Time { get; private set; }
        public int Price{get; private set; }

        public CallRecords(CallTypes callType, int number, DateTime date, DateTime time,int price)
        {
            CallType = callType;
            Number = number;
            Date = date;
            Time = time;
            Price = price;

       }
    }
}
