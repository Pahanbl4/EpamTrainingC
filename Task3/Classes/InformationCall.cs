using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
   public class InformationCall
    {
        public Guid Id { get; set; }
        public int MyNumber { get; set; }
        public int ObjectNumber { get; set; }
        public DateTime BeginCall { get; set; }
        public DateTime EndCall { get; set; }
        public int Price { get; set; }

        public InformationCall(int myNumbre, int objectNumber, DateTime beginCall)
        {
            Id = Guid.NewGuid();
            MyNumber = myNumbre;
            ObjectNumber = objectNumber;
            BeginCall = beginCall;
      
        }
    }
}
