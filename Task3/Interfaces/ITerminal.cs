using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;

namespace Task3.Interfaces
{
  public interface ITerminal
    {
        int Number { get; }

      //  event EventHandler<Request> OutGoingConnection; //срабатывает, когда терминал пытается подключиться к станции

        //event EventHandler<IncomingCallRequest> IncomingRequest; //срабатывает, когда станция пытается подключиться к терминалу

        //event EventHandler<Responds.Respond> IncomingRespond; //срабатывает при отправке терминала на станцию

      //  event EventHandler Online; //срабатывает, когда терминал переходит в режим вызова

        //event EventHandler Offline; //срабатывает, когда соединение прерывается

        //event EventHandler Plugging; //срабатывает, когда пользователь подключает устройство

        //event EventHandler UnPlugging; //срабатывает, когда пользователь отключает устройство

        void RaiseCallEvent(int number);
        void RaiseAnswerEvent(int number, StatusCall state);
        void Call(int number);
        void TakeIncomingCall(object sender, CallArgsEvent even);
        void ConnectToPort();
        void AnswerToCall(int number, StatusCall state);
        void RejectIncomingCall();
        void TakeAnswer(object sender, AnswerArgsEvent e);

    }
}
