using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Interfaces;

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

        public Terminal(int number,Port port)
        {
            _number = number;
            _terminalPort = port;
        }
         // public delegate void CallEventHandler(object sender, CallEventArgs e);
          public event EventHandler<CallArgsEvent> CallEvent;
        //  public delegate void AnswerEventHandler(object sender, AnswerEventArgs e);
          public event EventHandler<AnswerArgsEvent> AnswerEvent;

        public void AnswerToCall(int target, StatusCall state)
        {
            RaiseAnswerEvent(target, state); //вызов события
        }

        public void Call(int objectNumber)
        {
            RaiseCallEvent(objectNumber);
            Console.WriteLine("Звонок совершен");
        }

        public void ConnectToPort()
        {
         if(_terminalPort.Connect(this))
            {
                _terminalPort.IncomingCallEvent += TakeIncomingCall;
                _terminalPort.PortAnswerEvent += TakeAnswer;
            }
        }

        public void TakeIncomingCall(object sender, CallArgsEvent even)
        {
            Console.WriteLine("Have incoming call at number:{0} to terminal {1}", even.TelephoneNumber,even.ObjectTelephoneNumber);
        }

        public virtual void RaiseAnswerEvent(int objectNumber, StatusCall state)//генерация события
        {
           if(AnswerEvent!=null)
            {
                AnswerEvent(this, new AnswerArgsEvent(_number,objectNumber, state)); //запуск события
            }
        }

        public virtual void RaiseCallEvent(int objectNumber)//поднять звонок
        {
            if(CallEvent!=null)
            {
                CallEvent(this, new CallArgsEvent(_number, objectNumber));
            }
        }

        public void RejectIncomingCall()
        {
            throw new NotImplementedException();
        }

        public void TakeAnswer(object sender, AnswerArgsEvent even)
        {
            if(even.StatusInCall==StatusCall.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, have answer on call a number: {1}", even.TelephoneNumber, even.ObjectTelephoneNumber);
            }
            else
            { Console.WriteLine("Terminal with number: {0}, have rejected on call a number: {1}", even.TelephoneNumber, even.ObjectTelephoneNumber); }
           
        }
    }
}
