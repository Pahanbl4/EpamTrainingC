using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Interfaces;

namespace Task3.Classes
{
    public class Port : IPort
    {
        public StatusPort status;
        private ATS _ats;
        public bool flag;

        public delegate void PortEventHandler(object sender, CallEventArgs e);
        public event PortEventHandler IncomingCallEvent;
        public delegate void PortAnswerEventHandler(object sender, AnswerEventArgs e);
        public event PortAnswerEventHandler PortAnswerEvent;

        public Port(ATS ats)
        {
            status = StatusPort.UnPlugged;
            _ats = ats;
        }
        public Port()
        {
            status = StatusPort.UnPlugged;
         
        }
        public void AnswerCall(int outcomingNumber, StatusCall state)
        {
            throw new NotImplementedException();
        }

        public bool Connect(Terminal terminal)
        {
            if(status==StatusPort.UnPlugged)
            {
                status = StatusPort.Free;
                terminal.CallEvent += _ats.CallingTo;
                IncomingCallEvent += terminal.TakeIncomingCall;
                terminal.AnswerEvent += _ats.AnswerTo;
                PortAnswerEvent += terminal.TakeAnswer;
                flag = true;
            }
            return flag;
        }

        public bool Disconnect(Terminal terminal)
        {
            throw new NotImplementedException();
        }

        public void IncomingCall(int incomingNumber)
        {
            throw new NotImplementedException();
        }

        public void RaiseAnswerCallEvent(int outcomingNumber, StatusCall state)
        {
            throw new NotImplementedException();
        }

        public void RaiseIncomingCallEvent(int incomingNumber)
        {
            throw new NotImplementedException();
        }
    }
}
