using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
   public class AnswerEventArgs:EventArgs
    {
        public int _telephoneNumber;
        public int _objectTelephoneNumber;
        public StatusCall StatusCall;

        public AnswerEventArgs(int number,int objectTelephoneNumber,StatusCall status)
        {
            _telephoneNumber = number;
            _objectTelephoneNumber = objectTelephoneNumber;
            StatusCall = status;
        }
    }
}
