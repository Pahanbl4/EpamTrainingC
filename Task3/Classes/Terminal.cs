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

        public void AnswerToCall()
        {
            throw new NotImplementedException();
        }

        public void Call(int number)
        {
            throw new NotImplementedException();
        }

        public void ConnectToPort()
        {
            throw new NotImplementedException();
        }

        public void RaiseAnswerEvent(int number, StatusCall state)
        {
            throw new NotImplementedException();
        }

        public void RaiseCallEvent(int number)
        {
            throw new NotImplementedException();
        }

        public void RejectIncomingCall()
        {
            throw new NotImplementedException();
        }

        public void TakeAnswer(object sender, AnswerEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void TakeIncomingCall(object sender, CallEventArgs even)
        {
            throw new NotImplementedException();
        }
    }
}
