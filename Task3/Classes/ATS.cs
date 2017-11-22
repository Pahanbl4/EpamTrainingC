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
        private IList<int> _listtelephoneNumber;
        Random random;

        public ATS()
        {
            _listPort = new List<Port>();
            _listtelephoneNumber = new List<int>();
            random = new Random();
        }

        public Terminal GetNewTerminal(int numberTelephone)
        {
            //var newNumber = random.Next(1, 9);

            _listtelephoneNumber.Add(numberTelephone);
            var newPort = new Port(this);
            _listPort.Add(newPort);
            var newTerminal = new Terminal(numberTelephone, newPort);
            return newTerminal;
        }

        public void AnswerTo(object sender,AnswerEventArgs even)
        {
            if(_listtelephoneNumber.Contains(even._telephoneNumber))
            {
                var index = _listtelephoneNumber.IndexOf(even._telephoneNumber);
                if(_listPort[index].status== StatusPort.Free)
                {
                    _listPort[index].AnswerCall(even._objectTelephoneNumber,even._telephoneNumber, even.StatusCall);
                }
            }
        }

        public void CallingTo(object sender,CallEventArgs even)
        {
            if(_listtelephoneNumber.Contains(even.objectTelephoneNumber)&& even.objectTelephoneNumber!=even.telephoneNumber)
            {
                var index = _listtelephoneNumber.IndexOf(even.objectTelephoneNumber);
                if (_listPort[index].status == StatusPort.Free)
                {
                    _listPort[index].IncomingCall(even.telephoneNumber,even.objectTelephoneNumber);

                }
                else if (!_listtelephoneNumber.Contains(even.objectTelephoneNumber))
                {
                    Console.WriteLine("You have calling a non-existent number!!!");
                }
                else { Console.WriteLine("You have calling a your number!!!"); }
            }
        }

    }
}
