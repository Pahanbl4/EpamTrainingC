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
        private Guid _id;
        public Terminal(int number,Port port)
        {
            _number = number;
            _terminalPort = port;
        }
         // public delegate void CallEventHandler(object sender, CallEventArgs e);
          public event EventHandler<CallArgsEvent> CallEvent;
        //  public delegate void AnswerEventHandler(object sender, AnswerEventArgs e);
          public event EventHandler<AnswerArgsEvent> AnswerEvent;
         // public delegate void EndCallEventHandler(object sender, EndCallArgsEvent e);
          public event EventHandler<EndCallArgsEvent> EndCallEvent;

        public void AnswerToCall(int target, StatusCall state,Guid id)
        {
            RaiseAnswerEvent(target, state,id); //вызов события
        }

        public void Call(int objectNumber)
        {
            RaiseCallEvent(objectNumber);
          
        }

        public void ConnectToPort()
        {
         if(_terminalPort.Connect(this))
            {
                _terminalPort.PortCallEvent += TakeIncomingCall;
                _terminalPort.PortAnswerEvent += TakeAnswer;
            }
        }

        public void TakeIncomingCall(object sender, CallArgsEvent even)
        {
            bool flag = true;
            _id = even.Id;
            Console.WriteLine("Have incoming call at number:{0} to terminal {1}", even.TelephoneNumber,even.ObjectTelephoneNumber);

            while(flag==true)
            {
                Console.WriteLine("Reply? Yes=1 or No=0");
                char k = Console.ReadKey().KeyChar;
                if(k==1)
                {
                    flag = false;
                    Console.WriteLine();
                    AnswerToCall(even.TelephoneNumber, StatusCall.Answered, even.Id);
                }
                else if(k ==0)
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

        public virtual void RaiseAnswerEvent(int objectNumber, StatusCall state, Guid id)//генерация события
        {
           if(AnswerEvent!=null)
            {
                AnswerEvent(this, new AnswerArgsEvent(_number,objectNumber, state,id)); //запуск события
            }
        }

        public virtual void RaiseCallEvent(int objectNumber)//поднять звонок
        {
            if(CallEvent!=null)
            {
                CallEvent(this, new CallArgsEvent(_number, objectNumber));
             
            }
        }

        protected virtual void RaiseEndCallEvent(Guid id)
        {
            if (EndCallEvent != null)
                EndCallEvent(this, new EndCallArgsEvent(id, _number));
        }

        public void EndCall()
        {
            RaiseEndCallEvent(_id);
        }

        public void TakeAnswer(object sender, AnswerArgsEvent even)
        {
            _id = even.Id;
            if(even.StatusInCall==StatusCall.Answered)
            {
                Console.WriteLine("Terminal with number: {0}, have answer on call a number: {1}", even.TelephoneNumber, even.ObjectTelephoneNumber);
            }
            else
            { Console.WriteLine("Terminal with number: {0}, have rejected on call a number: {1}", even.TelephoneNumber, even.ObjectTelephoneNumber); }
           
        }
    }
}
