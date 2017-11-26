using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Arguments;
using Task3.Classes;

namespace Task3.Interfaces
{
  public interface IPort
    {
     
       
        bool Connect(Terminal terminal);
        bool Disconnect(Terminal terminal);
        void IncomingCall(int number, int objectNumber);
        void AnswerCall(int number, int objectNumber, StatusCall state);


        // event EventHandler<StatusPort> StatusChanging;
        // event EventHandler<StatusPort> StatusChanged;

    }
}
