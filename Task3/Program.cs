using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ATS ats = new ATS();
            //   var t1 = ats.GetNewTerminal();
            // var t2 = ats.GetNewTerminal();
            //  t1.ConnectToPort();
            // t2.ConnectToPort();
            // t1.Call(t2.Number);
            Contract contract1 = ats.RegisterContract(new Client("Ivan", "Ivanov", 30), TariffTypes.Standart);
            Contract contract2 = ats.RegisterContract(new Client("Ilja", "Iljin", 10), TariffTypes.Elementary);
            Contract contract3 = ats.RegisterContract(new Client("Dima", "Grachev", 50), TariffTypes.Lux);

            var t1 = ats.GetNewTerminal(contract1);
            var t2 = ats.GetNewTerminal(contract2);
            var t3 = ats.GetNewTerminal(contract3);

            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();

            t1.Call(t2.Number);
            t2.AnswerToCall(t1.Number, StatusCall.Rejected);
            t2.Call(t3.Number);
            t3.AnswerToCall(t2.Number, StatusCall.Answered);
            t2.Call(t2.Number);
          //  t2.Call(t2.Number);
            //t2.Call(1234567);
            Console.ReadKey();

        }
    }
}
