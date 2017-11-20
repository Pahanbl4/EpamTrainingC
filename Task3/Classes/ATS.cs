using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
  public  class ATS
    {
        private IList<Port> _listPort;
        private IList<int> _telephoneNumber;
        Random random;

        public ATS()
        {
            _listPort = new List<Port>();
            _telephoneNumber = new List<int>();
            random = new Random();
        }

        public Terminal GetNewTerminal()
        {
            var newNumber = random.Next(1, 9);
            _telephoneNumber.Add(newNumber);
            var newPort = new Port(this);
            _listPort.Add(newPort);
            var newTerminal = new Terminal(newNumber, newPort);
            return newTerminal;
        }

        public void AnswerTo(object sender,AnswerEventArgs even)
        {
            if(_telephoneNumber.Contains(even._telephoneNumber))
            {
                var index = _telephoneNumber.IndexOf(even._telephoneNumber);
                if(_listPort[index].status== StatusPort.Free)
                {
                    _listPort[index].AnswerCall(even._telephoneNumber, even.StatusCall);
                }
            }
        }

        public void CallingTo(object sender,CallEventArgs even)
        {
            if(_telephoneNumber.Contains(even.objectTelephoneNumber))
            {
                var index = _telephoneNumber.IndexOf(even.objectTelephoneNumber);
                if (_listPort[index].status == StatusPort.Free)
                {
                    _listPort[index].IncomingCall(even.telephoneNumber);

                }
            }
        }

    }
}
