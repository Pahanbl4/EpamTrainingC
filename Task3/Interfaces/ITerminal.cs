using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;
using Task3.Requests;

namespace Task3.Interfaces
{
  public interface ITerminal:IClearEventHandlers
    {
        PhoneNumber Number { get; }

        event EventHandler<Request> OutGoingConnection; //срабатывает, когда терминал пытается подключиться к станции

        event EventHandler<IncomingCallRequest> IncomingRequest; //срабатывает, когда станция пытается подключиться к терминалу

        event EventHandler<Responds.Respond> IncomingRespond; //срабатывает при отправке терминала на станцию

        event EventHandler Online; //срабатывает, когда терминал переходит в режим вызова

        event EventHandler Offline; //срабатывает, когда соединение прерывается

        event EventHandler Plugging; //срабатывает, когда пользователь подключает устройство

        event EventHandler UnPlugging; //срабатывает, когда пользователь отключает устройство

        void Call(PhoneNumber target);
        void IncomingRequestFrom(PhoneNumber sourse);
        void Drop();
        void Answer();
        void Plug();
        void UnPlug();
        void RegistrEventHandlerForPort(IPort port);

    }
}
