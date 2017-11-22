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
          public delegate void CallEventHandler(object sender, CallEventArgs e);
          public event CallEventHandler CallEvent;
          public delegate void AnswerEventHandler(object sender, AnswerEventArgs e);
          public event AnswerEventHandler AnswerEvent;

        public void AnswerToCall(int number, StatusCall state)
        {
            RaiseAnswerEvent(number, state);
        }

        public void Call(int objectNumber)
        {
            RaiseCallEvent(objectNumber);
        }

        public void ConnectToPort()
        {
            _terminalPort.Connect(this);
        }
        public void TakeIncomingCall(object sender, CallEventArgs even)
        {
            Console.WriteLine("Have incoming call at number:{0} to terminal {1}", even.telephoneNumber,even.objectTelephoneNumber);
        }

        public virtual void RaiseAnswerEvent(int incomingNumber, StatusCall state)
        {
           if(AnswerEvent!=null)
            {
                AnswerEvent(this, new AnswerEventArgs(incomingNumber, _number, state));
            }
        }

        public virtual void RaiseCallEvent(int objectNumber)//поднять звонок
        {
            if(CallEvent!=null)
            {
                CallEvent(this, new CallEventArgs(_number, objectNumber));
            }
        }

        public void RejectIncomingCall()
        {
            throw new NotImplementedException();
        }

        public void TakeAnswer(object sender, AnswerEventArgs even)
        {
            if(even.StatusCall==StatusCall.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, have answer on call a number: {1}", even._objectTelephoneNumber, even._telephoneNumber);
            }
            else
            { Console.WriteLine("Terminal with number: {0}, have rejected on call a number: {1}", even._objectTelephoneNumber, even._telephoneNumber); }
           
        }
    }
}
