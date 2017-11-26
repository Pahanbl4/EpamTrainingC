using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Arguments;
using Task3.Classes;
using Task3.Bylling;

namespace Task3.Interfaces
{
  public interface ITerminal
    {
        int Number { get; }
        void DoCallEvent(int number);
        void DoAnswerEvent(int objectNumber, StatusCall state, Guid id);
        void Call(int number);
        void TakeIncomingCall(object sender, CallArgsEvent even);
        void ConnectToPort();
        void AnswerToCall(int target, StatusCall state, Guid id);
        void EndCall();
        void TakeAnswer(object sender, AnswerArgsEvent e);

    }
}
