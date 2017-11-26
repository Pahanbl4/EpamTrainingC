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
    public class Terminal : ITerminal
    {
        private int _number;
        public int Number
        {
            get { return _number; }
        }
        private Port _terminalPort;
        private Guid _id;

        public Terminal(int number,Port port)
        {
            _number = number;
            _terminalPort = port;
        }
          public event EventHandler<CallArgsEvent> CallEvent;
          public event EventHandler<AnswerArgsEvent> AnswerEvent;
          public event EventHandler<EndCallArgsEvent> EndCallEvent;



        public virtual void DoAnswerEvent(int objectNumber, StatusCall status, Guid id)//генерация события
        {
            AnswerEvent?.Invoke(this, new AnswerArgsEvent(_number, objectNumber, status, id)); //запуск события
        }

        public virtual void DoCallEvent(int objectNumber)//генерация события
        {
            CallEvent?.Invoke(this, new CallArgsEvent(_number, objectNumber));
        }

        protected virtual void DoEndCallEvent(Guid id)
        {
            EndCallEvent?.Invoke(this, new EndCallArgsEvent(id, _number));
        }

        public void Call(int objectNumber)
        {
            DoCallEvent(objectNumber);
        }

        public void TakeIncomingCall(object sender, CallArgsEvent even)
        {
            bool flag = true;
            _id = even.Id;
            Console.WriteLine("Incoming call at number:{0} to terminal {1}", even.TelephoneNumber,even.ObjectTelephoneNumber);

            while(flag==true)
            {
                Console.WriteLine("Reply? Yes or No");
                char n = Console.ReadKey().KeyChar;
                if (n == 'y')
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(even.TelephoneNumber, StatusCall.Answered, even.Id);
                    continue;
                }
                else if (n =='n')
                {
                    flag = false;
                    Console.WriteLine();
                    EndCall();
                }
                else
                {
                    flag = true;
                    Console.WriteLine();
                }
                
            }
        }

        public void AnswerToCall(int target, StatusCall state, Guid id)
        {
            DoAnswerEvent(target, state, id); //вызов события
        }

        public void ConnectToPort()
        {
            if (_terminalPort.Connect(this))
            {
                _terminalPort.PortCallEvent += TakeIncomingCall;
                _terminalPort.PortAnswerEvent += TakeAnswer;
            }
        }

        public void EndCall()
        {
            DoEndCallEvent(_id);
        }

        public void TakeAnswer(object sender, AnswerArgsEvent even)
        {
            _id = even.Id;
            if(even.StatusInCall==StatusCall.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, have answer on call a number: {1}", even.TelephoneNumber, even.ObjectTelephoneNumber);
            }
            else
            { Console.WriteLine("Terminal with number: {0}, have rejected call ", even.TelephoneNumber); }
           
        }
    }
}
