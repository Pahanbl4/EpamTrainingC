using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public class ATS
    {
        //  private IList<Port> _listPort;
        //private IList<int> _listtelephoneNumber;
        private IDictionary<int, Tuple<Port, Contract>> _userData;
        Random random;

        public ATS()
        {
            _userData = new Dictionary<int, Tuple<Port, Contract>>();
            random = new Random();
        }

        public Terminal GetNewTerminal(Contract contract)
        {
            //var newNumber = random.Next(1, 9);

            // _listtelephoneNumber.Add(numberTelephone);
            // var newPort = new Port(this);
            // _listPort.Add(newPort);
            // var newTerminal = new Terminal(numberTelephone, newPort);
            var newPort = new Port();
            newPort.AnswerEvent += CallingTo;
            newPort.CallEvent += CallingTo;
            _userData.Add(contract.Number, new Tuple<Port, Contract>(newPort, contract));
            var newTerminal = new Terminal(contract.Number, newPort);
            return newTerminal;
        }

        public Contract RegisterContract(Client subscriber, TariffTypes type)
        {
            var contract = new Contract(subscriber, type);
            //_listContract.Add(contract);
            return contract;
        }

        public void CallingTo(object sender, ICallingArgsEvent e)//ссылка на объект который вызвал данное событие,инфа о событие
        {
            if (_userData.ContainsKey(e.ObjectTelephoneNumber) && e.ObjectTelephoneNumber != e.TelephoneNumber)
            {

                var port = _userData[(e.ObjectTelephoneNumber)].Item1;
                                if (port.Status == StatusPort.Connect)
                {
                    var tuple = _userData[(e.ObjectTelephoneNumber)];
                    if (e is AnswerArgsEvent)
                    {

                        var answerArgs = (AnswerArgsEvent)e;
                        if (answerArgs.StatusInCall == StatusCall.Answered)
                        {
                            //var tuple = _usersData[(e.TargetTelephoneNumber)];
                            tuple.Item2.Client.RemoveMoney(tuple.Item2.Tariff.PriceOfCall);
                        }
                        port.AnswerCall(answerArgs.TelephoneNumber, answerArgs.ObjectTelephoneNumber, answerArgs.StatusInCall);
                    }
                    if (e is CallArgsEvent)
                    {
                        if (tuple.Item2.Client.Money > 0)   ///допилить в зависимости от тарифа
                        {
                            var callArgs = (CallArgsEvent)e;
                            port.IncomingCall(callArgs.TelephoneNumber, callArgs.ObjectTelephoneNumber);
                        }
                    }
                }
            }
        }
    }
}
