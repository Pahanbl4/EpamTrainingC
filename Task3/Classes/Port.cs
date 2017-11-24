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
        public StatusPort Status;
  
        public bool Flag;

       // public delegate void CallEventHandler(object sender, CallArgsEvent e);
        public event EventHandler<CallArgsEvent> IncomingCallEvent;
        // public delegate void AnswerEventHandler(object sender, AnswerArgsEvent e);
        public event EventHandler<AnswerArgsEvent> PortAnswerEvent;
        //  public delegate void CallEventHandler(object sender, CallArgsEvent e);
        public event EventHandler<CallArgsEvent> CallEvent;
       // public delegate void AnswerEventHandler(object sender, AnswerArgsEvent e);
        public event EventHandler<AnswerArgsEvent> AnswerEvent;

        public Port()
        {
            Status = StatusPort.UnPlugged;
         
        }
    

        public bool Connect(Terminal terminal)
        {
            if(Status==StatusPort.Disconnect)
            {//подписка на событие
                Status = StatusPort.Connect;

                terminal.CallEvent += CallingTo;            
                terminal.AnswerEvent += AnswerTo;            
                Flag = true;
            }
            return Flag;
        }

        public bool Disconnect(Terminal terminal)
        {
         if(Status==StatusPort.Connect)
            {
                Status = StatusPort.Disconnect;
                terminal.CallEvent -= CallingTo;
                terminal.AnswerEvent -= AnswerTo;
                Flag = false;

            }
            return Flag;
        }

        public void IncomingCall(int number,int objectNumber)
        {
            RaiseIncomingCallEvent(number, objectNumber);
        }

        public void AnswerCall(int number, int objectNumber, StatusCall state)
        {
            RaiseAnswerCallEvent(number, objectNumber, state);
        }

        private void CallingTo(object sender, CallArgsEvent even)
        {
            RaiseCallingToEvent(even.TelephoneNumber, even.ObjectTelephoneNumber);
        }

        private void AnswerTo(object sebder, AnswerArgsEvent even)
        {
            RaiseAnswerCallEvent(even.TelephoneNumber, even.ObjectTelephoneNumber, even.StatusInCall);
        }
        //генерпция события
        protected virtual void RaiseAnswerCallEvent(int number,int objectNumber, StatusCall state)
        {
            if(PortAnswerEvent!=null)
            {
                PortAnswerEvent(this, new AnswerArgsEvent(number, objectNumber, state));//запуск события
            }
        }

        protected virtual void RaiseIncomingCallEvent(int number,int objectNumber)
        {
           if(IncomingCallEvent!=null)
            {
                IncomingCallEvent(this, new CallArgsEvent(number, objectNumber));
            }
        }

        protected virtual void RaiseCallingToEvent(int number, int targetNumber)
        {
            if(CallEvent !=null)
            {
                CallEvent(this, new CallArgsEvent(number, targetNumber));
            }
        }
        protected virtual void RaiseAnswerToEvent(int number, int objectNumber, StatusCall state)
        {
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new AnswerArgsEvent(number, objectNumber, state));//запуск события
            }
        }


    }
}
