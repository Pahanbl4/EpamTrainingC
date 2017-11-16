using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public delegate void PushPrinterButton();

        static void Main(string[] args)
        {
            mouse mouse = new mouse();
            mouse.Click += new PushPrinterButton(mouse.Onklick);
            mouse.StartEvent();
        }

        class mouse
        {
            public event PushPrinterButton Click;

            public void StartEvent()
            {
                if (Click != null)
                {
                    Onklick();
                }
            }

            public void Onklick()
            {
                Console.WriteLine("нажата кнопка принт");
            }
        }
    }
}
