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
        public void AnswerCall(int number,int outcomingNumber, StatusCall state)
        {
            RaiseAnswerCallEvent( number, outcomingNumber, state);
        }

        public bool Connect(Terminal terminal)
        {
            if(status==StatusPort.Busy)
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
         if(status==StatusPort.Free)
            {
                status = StatusPort.Busy;
                terminal.CallEvent -= _ats.CallingTo;
                IncomingCallEvent -= terminal.TakeIncomingCall;
                flag = false;

            }
            return flag;
        }

        public void IncomingCall(int number,int incomingNumber)
        {
            RaiseIncomingCallEvent(number,incomingNumber);
        }

        public void RaiseAnswerCallEvent(int outcomingNumber,int number, StatusCall state)
        {
            if(PortAnswerEvent!=null)
            {
                PortAnswerEvent(this, new AnswerEventArgs(outcomingNumber, number, state));
            }
        }

        public void RaiseIncomingCallEvent(int number,int incomingNumber)
        {
           if(IncomingCallEvent!=null)
            {
                IncomingCallEvent(this, new CallEventArgs(number, incomingNumber));
            }
        }
    }
}
