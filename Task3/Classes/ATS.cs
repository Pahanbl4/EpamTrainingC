using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Interfaces;
using Task3.Arguments;
using Task3.Bylling;

namespace Task3.Classes
{
    public class ATS:IATS
    {
        private IDictionary<int, Tuple<Port, Contract>> _userData;
        private IList<InformationCall> _callList = new List<InformationCall>();

        public ATS()
        {
            _userData = new Dictionary<int, Tuple<Port, Contract>>();
        }

        public Terminal GetNewTerminal(Contract contract)
        {
            var newPort = new Port();
            newPort.AnswerEvent += CallingTo;
            newPort.CallEvent += CallingTo;
            newPort.EndCallEvent += CallingTo;
            _userData.Add(contract.Number, new Tuple<Port, Contract>(newPort, contract));
            var newTerminal = new Terminal(contract.Number, newPort);
            return newTerminal;
        }

        public Contract RegisterContract(Client client, TariffTypes type)
        {
            var contract = new Contract(client, type);
            return contract;
        }

        public void CallingTo(object sender, ICallingArgsEvent even)//ссылка на объект который вызвал данное событие,инфа о событие
        {
            if ((_userData.ContainsKey(even.ObjectTelephoneNumber) && even.ObjectTelephoneNumber != even.TelephoneNumber) || even is EndCallArgsEvent)
            {
                InformationCall informationCall = null;
                Port objectPort;
                Port port;
                int number = 0;
                int objectNumber = 0;
                if(even is EndCallArgsEvent)
                {
                    var callListFirst = _callList.First(x => x.Id.Equals(even.Id));
                    if(callListFirst.MyNumber == even.TelephoneNumber)
                    {
                        objectPort = _userData[callListFirst.ObjectNumber].Item1;
                        port = _userData[callListFirst.MyNumber].Item1;
                        number = callListFirst.MyNumber;
                        objectNumber = callListFirst.ObjectNumber;
                    }
                    else
                    {
                        port = _userData[callListFirst.ObjectNumber].Item1;
                        objectPort = _userData[callListFirst.MyNumber].Item1;
                        objectNumber = callListFirst.MyNumber;
                        number = callListFirst.ObjectNumber;
                    }
                }
                else
                {
                    objectPort = _userData[even.ObjectTelephoneNumber].Item1;
                    port = _userData[even.TelephoneNumber].Item1;
                    objectNumber = even.ObjectTelephoneNumber;
                    number = even.TelephoneNumber;
                }

                if (objectPort.Status == StatusPort.Connect && port.Status == StatusPort.Connect)
                {
                    var tuple = _userData[number];
                    var objectTuple = _userData[objectNumber];


                    if (even is AnswerArgsEvent answerArgs)
                    {
                        InformationCall information = null;

                        if (!answerArgs.Id.Equals(Guid.Empty) && _callList.Any(x => x.Id.Equals(answerArgs.Id)))
                        {
                            information = _callList.First(x => x.Id.Equals(answerArgs.Id));
                        }
                        if (information != null)
                        {
                            objectPort.AnswerCall(answerArgs.TelephoneNumber, answerArgs.ObjectTelephoneNumber, answerArgs.StatusInCall, information.Id);
                        }
                        else
                        {
                            objectPort.AnswerCall(answerArgs.TelephoneNumber, answerArgs.ObjectTelephoneNumber, answerArgs.StatusInCall);
                        }

                    }
                    if (even is CallArgsEvent)
                    {
                        if (tuple.Item2.Client.Money > tuple.Item2.Tariff.PriceOfCallPerMinute)
                        {
                            var callArgs = (CallArgsEvent)even;
                        
                            if (callArgs.Id.Equals(Guid.Empty))
                            {
                                informationCall = new InformationCall(callArgs.TelephoneNumber, callArgs.ObjectTelephoneNumber,DateTime.Now);
                                _callList.Add(informationCall);                              
                            }

                            if (!callArgs.Id.Equals(Guid.Empty) && _callList.Any(x => x.Id.Equals(callArgs.Id)))
                            {
                                informationCall = _callList.First(x => x.Id.Equals(callArgs.Id));
                            }
                            if (informationCall != null)
                            {
                                objectPort.IncomingCall(callArgs.TelephoneNumber, callArgs.ObjectTelephoneNumber, informationCall.Id);
                            }
                            else
                            {
                                objectPort.IncomingCall(callArgs.TelephoneNumber, callArgs.ObjectTelephoneNumber);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Terminal with number {0} is not enough money in the account!", even.TelephoneNumber);
                        }
                        }
                    if(even is EndCallArgsEvent)
                    {
                        var args = (EndCallArgsEvent)even;
                        informationCall = _callList.First(x => x.Id.Equals(args.Id));
                        informationCall.EndCall = DateTime.Now;
                        var sumOfCall = tuple.Item2.Tariff.PriceOfCallPerMinute * TimeSpan.FromTicks((informationCall.EndCall - informationCall.BeginCall).Ticks).TotalMinutes;
                        informationCall.Price = (int)sumOfCall;
                        objectTuple.Item2.Client.RemoveMoney(informationCall.Price);
                        objectPort.AnswerCall(args.TelephoneNumber, args.ObjectTelephoneNumber, StatusCall.Rejected, informationCall.Id);
                    }
                    }
                }
            else if (!_userData.ContainsKey(even.ObjectTelephoneNumber))
            {
                Console.WriteLine("You have calling a non-existent number");
            }
            else
            {
                Console.WriteLine("You have calling a your number");
            }
        }

        public IList<InformationCall> GetInfoList()
        {
            return _callList;
        }
    }
}

