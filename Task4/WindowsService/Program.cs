﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        static void Main()
        {
#if DEBUG
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);


#else
            
            Service1 myService1 = new Service1();
            myService1.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            
#endif
        }
    }
}
