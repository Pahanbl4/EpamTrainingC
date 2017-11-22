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
            Contract contract1 = new Contract("qo200", 7890156, TariffTypes.Elementary, ats);
            Contract contract2 = new Contract("qo400", 6204733, TariffTypes.Standart, ats);
            Contract contract3 = new Contract("qo1000", 6202211, TariffTypes.Lux, ats);

            var t1 = contract1.RegistrContract();
            var t2 = contract2.RegistrContract();
            var t3 = contract3.RegistrContract();

            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();

            t1.Call(t2.Number);
            t2.AnswerToCall(t1.Number, StatusCall.Rejected);
            t2.Call(t3.Number);
            t3.AnswerToCall(t2.Number, StatusCall.Answered);
            t2.Call(t2.Number);
            t2.Call(t2.Number);
            t2.Call(1234567);
            Console.ReadKey();

        }
    }
}
