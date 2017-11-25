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
        public event EventHandler<CallArgsEvent> PortCallEvent;
        // public delegate void AnswerEventHandler(object sender, AnswerArgsEvent e);
        public event EventHandler<AnswerArgsEvent> PortAnswerEvent;
        //  public delegate void CallEventHandler(object sender, CallArgsEvent e);
        public event EventHandler<CallArgsEvent> CallEvent;
       // public delegate void AnswerEventHandler(object sender, AnswerArgsEvent e);
        public event EventHandler<AnswerArgsEvent> AnswerEvent;

        public event EventHandler<EndCallArgsEvent> EndCallEvent;

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
                terminal.EndCallEvent += EndCall;
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
                terminal.EndCallEvent += EndCall;
                Flag = false;

            }
            return Flag;
        }
        public void IncomingCall(int number, int objectNumber)
        {
            RaiseIncomingCallEvent(number, objectNumber);
        }

        public void AnswerCall(int number, int objectNumber, StatusCall state)
        {
            RaiseAnswerCallEvent(number, objectNumber, state);
        }

        public void IncomingCall(int number,int objectNumber,Guid id)
        {
            RaiseIncomingCallEvent(number, objectNumber,id);
        }

        public void AnswerCall(int number, int objectNumber, StatusCall state,Guid id)
        {
            RaiseAnswerCallEvent(number, objectNumber, state,id);
        }

        private void CallingTo(object sender, CallArgsEvent even)
        {
            RaiseCallingToEvent(even.TelephoneNumber, even.ObjectTelephoneNumber);
        }

        private void AnswerTo(object sender, AnswerArgsEvent even)
        {
            RaiseAnswerToEvent(even);

        }

        private void EndCall(object sender,EndCallArgsEvent even)
        {
            RaiseEndCallEvent(even.Id, even.TelephoneNumber);
        }

        //генерпция события
        protected virtual void RaiseAnswerCallEvent(int number,int objectNumber, StatusCall status,Guid id)
        {
            if(PortAnswerEvent!=null)
            {
                PortAnswerEvent(this, new AnswerArgsEvent(number, objectNumber, status,id));//запуск события
            }
        }

        protected virtual void RaiseAnswerCallEvent(int number, int objectNumber, StatusCall status)
        {
            if (PortAnswerEvent != null)
            {
                PortAnswerEvent(this, new AnswerArgsEvent(number, objectNumber, status));//запуск события
            }
        }

        protected virtual void RaiseIncomingCallEvent(int number,int objectNumber,Guid id)
        {
           if(PortCallEvent!=null)
            {
                PortCallEvent(this, new CallArgsEvent(number, objectNumber,id));
            }
        }

        protected virtual void RaiseIncomingCallEvent(int number, int objectNumber)
        {
            if (PortCallEvent != null)
            {
                PortCallEvent(this, new CallArgsEvent(number, objectNumber));
            }
        }

        protected virtual void RaiseCallingToEvent(int number, int targetNumber)
        {
            if(CallEvent !=null)
            {
                CallEvent(this, new CallArgsEvent(number, targetNumber));
            }
        }
        protected virtual void RaiseAnswerToEvent(AnswerArgsEvent even)
        {
            if (AnswerEvent != null)
            {
                AnswerEvent(this, new AnswerArgsEvent(even.TelephoneNumber, even.ObjectTelephoneNumber, even.StatusInCall, even.Id));//запуск события
            }
        }
        protected virtual void RaiseEndCallEvent(Guid id,int number)

        {
            if(EndCallEvent!=null)
            {
                EndCallEvent(this, new EndCallArgsEvent(id, number));
            }
        }


    }
}
