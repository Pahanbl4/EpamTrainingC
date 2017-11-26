﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Classes;
using Task3.Bylling;
using System.Threading;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ATS ats = new ATS();
            ReportShow show = new ReportShow();
            BillingSystem billingSystem = new BillingSystem(ats);
            Contract contract1 = ats.RegisterContract(new Client("Ivan", "Ivanov", 30), TariffTypes.Standart);
            contract1.Client.AddMoney(10);
            Contract contract2 = ats.RegisterContract(new Client("Ilja", "Iljin", 10), TariffTypes.Elementary);
            Contract contract3 = ats.RegisterContract(new Client("Dima", "Grachev", 50), TariffTypes.Lux);


            contract1.Client.AddMoney(50);
            var t1 = ats.GetNewTerminal(contract1);
            var t2 = ats.GetNewTerminal(contract2);
            var t3 = ats.GetNewTerminal(contract3);

            t1.ConnectToPort();
            t2.ConnectToPort();
            t3.ConnectToPort();

            t1.Call(t2.Number);
          
            Thread.Sleep(2000);
            t2.EndCall();

            t3.Call(t1.Number);
            Thread.Sleep(1000);
            t3.EndCall();

            t2.Call(t1.Number);
            Thread.Sleep(3000);
            t1.EndCall();
    

            Console.WriteLine();
            Console.WriteLine("Sorted records:");
            foreach (var item in show.SortCalls(billingSystem.GetReport(t1.Number), SortType.SortByTypeCall))
            {
                Console.WriteLine("Calls:\n Type {0} |\n Date: {1} |\n Duration: {2} | Cost: {3} | Telephone number: {4}",
                    item.CallType, item.Date, item.Time.ToString("mm:ss"), item.Price, item.Number);
            }
            Console.ReadKey();

        }
    }
}
