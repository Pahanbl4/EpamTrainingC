using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
   public class CallEventArgs:EventArgs
    {
        public int telephoneNumber;
        public int objectTelephoneNumber;

        public CallEventArgs(int number, int target)
        {
            telephoneNumber = number;
            objectTelephoneNumber = target;
        }
    }
}
