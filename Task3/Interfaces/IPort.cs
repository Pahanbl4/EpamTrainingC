using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;

namespace Task3.Interfaces
{
  public interface IPort
    {
     
       
        bool Connect(Terminal terminal);
        bool Disconnect(Terminal terminal);
        void RaiseIncomingCallEvent(int number, int incomingNumber);
        void RaiseAnswerCallEvent(int outcomingNumber, int number, StatusCall state);
        void IncomingCall(int number, int incomingNumber);
        void AnswerCall(int number, int outcomingNumber, StatusCall state);


        // event EventHandler<StatusPort> StatusChanging;
        // event EventHandler<StatusPort> StatusChanged;

    }
}
