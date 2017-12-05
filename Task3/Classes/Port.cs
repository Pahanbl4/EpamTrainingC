using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Interfaces;
using Task3.Arguments;

namespace Task3.Classes
{
    public class Port : IPort
    {
        public StatusPort Status;
  
        public bool Flag;

        public event EventHandler<CallArgsEvent> PortCallEvent;
        public event EventHandler<AnswerArgsEvent> PortAnswerEvent;
        public event EventHandler<CallArgsEvent> CallEvent;
        public event EventHandler<AnswerArgsEvent> AnswerEvent;
        public event EventHandler<EndCallArgsEvent> EndCallEvent;

        public Port()
        {
            Status = StatusPort.Disconnect;
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
       



        public void IncomingCall(int number,int objectNumber,Guid id)
        {
            DoIncomingCallEvent(number, objectNumber,id);
        }

        public void IncomingCall(int number, int objectNumber)
        {
            DoIncomingCallEvent(number, objectNumber);
        }

        public void AnswerCall(int number, int objectNumber, StatusCall state,Guid id)
        {
            DoAnswerCallEvent(number, objectNumber, state,id);
        }

        public void AnswerCall(int number, int objectNumber, StatusCall state)
        {
            DoAnswerCallEvent(number, objectNumber, state);
        }

        private void CallingTo(object sender, CallArgsEvent even) //обработчики события
        {
            DoCallingToEvent(even.TelephoneNumber, even.ObjectTelephoneNumber);
        }

        private void AnswerTo(object sender, AnswerArgsEvent even)
        {
            DoAnswerToEvent(even);
        }

        private void EndCall(object sender,EndCallArgsEvent even)
        {
            DoEndCallEvent(even.Id, even.TelephoneNumber);
        }

        //генерпция события
        protected virtual void DoAnswerCallEvent(int number,int objectNumber, StatusCall status,Guid id)
        {
            PortAnswerEvent?.Invoke(this, new AnswerArgsEvent(number, objectNumber, status, id));//запуск события
        }

        protected virtual void DoAnswerCallEvent(int number, int objectNumber, StatusCall status)
        {
            PortAnswerEvent?.Invoke(this, new AnswerArgsEvent(number, objectNumber, status));//запуск события
        }

        protected virtual void DoIncomingCallEvent(int number,int objectNumber,Guid id)
        {
            PortCallEvent?.Invoke(this, new CallArgsEvent(number, objectNumber, id));
        }

        protected virtual void DoIncomingCallEvent(int number, int objectNumber)
        {
            PortCallEvent?.Invoke(this, new CallArgsEvent(number, objectNumber));
        }

        protected virtual void DoCallingToEvent(int number, int targetNumber)
        {
            CallEvent?.Invoke(this, new CallArgsEvent(number, targetNumber));
        }
        protected virtual void DoAnswerToEvent(AnswerArgsEvent even)
        {
            AnswerEvent?.Invoke(this, new AnswerArgsEvent(even.TelephoneNumber, even.ObjectTelephoneNumber, even.StatusInCall, even.Id));//запуск события
        }
        protected virtual void DoEndCallEvent(Guid id,int number)
        {
            EndCallEvent?.Invoke(this, new EndCallArgsEvent(id, number));
        }


    }
}
